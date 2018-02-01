namespace CopyBinaryFile
{
    using System.IO;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (FileStream source = new FileStream("../copyMe.png", FileMode.Open))
            {
                using (FileStream target = new FileStream("../copyMe-copy.png", FileMode.Create))
                {
                    // One MiB... Fancy presented...
                    byte[] buffer = new byte[(int)Math.Pow(1024, 2)];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        target.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}