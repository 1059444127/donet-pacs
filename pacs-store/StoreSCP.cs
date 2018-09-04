using Dicom;
using Dicom.Log;
using Dicom.Network;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace pacs_store
{
    public class StoreSCP
    {
        public static string StoragePath = "./dicom";
        public static string port = "104";

        public void run()
        {
            // 预加载一个字典预防超时
            var dict = DicomDictionary.Default;

            // 设置端口
            var port = int.Parse(StoreSCP.port);
            Console.WriteLine($"Starting C-Store SCP server on port {port}");
            var server = DicomServer.Create<CStoreSCP>(port);

            // end process
            Console.WriteLine("Press <return> to end...");
            Console.ReadLine();
        }

        private class CStoreSCP : DicomService, IDicomServiceProvider, IDicomCStoreProvider, IDicomCEchoProvider
        {
            private static readonly DicomTransferSyntax[] AcceptedTransferSyntaxes = new DicomTransferSyntax[]
            {
               DicomTransferSyntax.ExplicitVRLittleEndian,
               DicomTransferSyntax.ExplicitVRBigEndian,
               DicomTransferSyntax.ImplicitVRLittleEndian
            };

            private static readonly DicomTransferSyntax[] AcceptedImageTransferSyntaxes = new DicomTransferSyntax[]
            {
               // Lossless
               DicomTransferSyntax.JPEGLSLossless,
               DicomTransferSyntax.JPEG2000Lossless,
               DicomTransferSyntax.JPEGProcess14SV1,
               DicomTransferSyntax.JPEGProcess14,
               DicomTransferSyntax.RLELossless,
               // Lossy
               DicomTransferSyntax.JPEGLSNearLossless,
               DicomTransferSyntax.JPEG2000Lossy,
               DicomTransferSyntax.JPEGProcess1,
               DicomTransferSyntax.JPEGProcess2_4,
               // Uncompressed
               DicomTransferSyntax.ExplicitVRLittleEndian,
               DicomTransferSyntax.ExplicitVRBigEndian,
               DicomTransferSyntax.ImplicitVRLittleEndian
            };

            public CStoreSCP(INetworkStream stream, Encoding fallbackEncoding, Logger log)
                : base(stream, fallbackEncoding, log)
            {
            }

            public Task OnReceiveAssociationRequestAsync(DicomAssociation association)
            {
                if (association.CalledAE != "STORESCP")
                {
                    return SendAssociationRejectAsync(
                        DicomRejectResult.Permanent,
                        DicomRejectSource.ServiceUser,
                        DicomRejectReason.CalledAENotRecognized);
                }

                foreach (var pc in association.PresentationContexts)
                {
                    if (pc.AbstractSyntax == DicomUID.Verification) pc.AcceptTransferSyntaxes(AcceptedTransferSyntaxes);
                    else if (pc.AbstractSyntax.StorageCategory != DicomStorageCategory.None) pc.AcceptTransferSyntaxes(AcceptedImageTransferSyntaxes);
                }

                return SendAssociationAcceptAsync(association);
            }

            public Task OnReceiveAssociationReleaseRequestAsync()
            {
                return SendAssociationReleaseResponseAsync();
            }

            public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
            {
            }

            public void OnConnectionClosed(Exception exception)
            {
            }

            public DicomCStoreResponse OnCStoreRequest(DicomCStoreRequest request)
            {
                var studyUid = request.Dataset.GetSingleValue<string>(DicomTag.StudyInstanceUID);
                var instUid = request.SOPInstanceUID.UID;

                var path = Path.GetFullPath(StoragePath);
                path = Path.Combine(path, studyUid);

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                path = Path.Combine(path, instUid) + ".dcm";

                request.File.Save(path);
                // 保存数据库

                return new DicomCStoreResponse(request, DicomStatus.Success);
            }

            public void OnCStoreRequestException(string tempFileName, Exception e)
            {
                // let library handle logging and error response
            }

            public DicomCEchoResponse OnCEchoRequest(DicomCEchoRequest request)
            {
                return new DicomCEchoResponse(request, DicomStatus.Success);
            }
        }
    }
}
