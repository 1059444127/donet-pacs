namespace pacs_store
{
    public class CStoreSCP
    {
        public static string StoragePath = "./dicom";

        public void run()
        {
            // 预加载一个字典预防超时
            var dict = DicomDictionary.Default;

        }
    }
}
