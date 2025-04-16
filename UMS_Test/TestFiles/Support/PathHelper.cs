namespace UMS.UI.Test.ERP.TestFiles.Support
{
    public class PathHelper
    {
        public string GetAbsolutePath(string inputPath)
        {
            if (string.IsNullOrWhiteSpace(inputPath))
            {
                throw new ArgumentException("Path cannot be null or empty");
            }

            // Handle both forward and backward slashes
            string normalizedPath = inputPath.Replace('/', '\\').Trim();

            // Check if path is already absolute
            if (Path.IsPathRooted(normalizedPath))
            {
                // Verify the absolute path exists (file or directory)
                if (File.Exists(normalizedPath) || Directory.Exists(normalizedPath))
                {
                    return normalizedPath;
                }
                throw new FileNotFoundException($"The path '{normalizedPath}' does not exist");
            }

            // Handle relative paths
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.GetFullPath(Path.Combine(baseDirectory, normalizedPath));

                // Verify the resolved path exists
                if (File.Exists(fullPath) || Directory.Exists(fullPath))
                {
                    return fullPath;
                }
                throw new FileNotFoundException($"The resolved path '{fullPath}' does not exist");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to resolve path '{inputPath}': {ex.Message}", ex);
            }
        }
    }
}
