namespace CASHelpers.TypeConverters
{
    public static class HexConverter
    {
        public static byte[] HexStringToByteArray(string hexString)
        {
            // Check if the input string is an even number of characters
            if (hexString.Length % 2 != 0)
                throw new ArgumentException("Hexadecimal string must have an even number of characters.");

            // Calculate the length of the byte array
            int byteCount = hexString.Length / 2;

            // Create a byte array to store the result
            byte[] byteArray = new byte[byteCount];

            // Convert each pair of characters to a byte
            for (int i = 0; i < byteCount; i++)
            {
                byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return byteArray;
        }
    }
}
