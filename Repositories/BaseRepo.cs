using System.Reflection;

namespace Repositories
{
    public abstract class BaseRepo
    {
        private Assembly _assembly = Assembly.GetExecutingAssembly();

        protected async Task<string> GetFileFromAssemblyAsync(string fileName)
        {
            var assemblyFiles = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            var assemblyFile = assemblyFiles.FirstOrDefault(f => f.EndsWith(fileName));

            if (assemblyFile == null)
            {
                throw new Exception($"File '{fileName}' not found in assembly.");
            }
            else
            {
                string content = await new StreamReader(_assembly.GetManifestResourceStream(assemblyFile) ?? throw new Exception($"Could not read file '{fileName}' from assembly.")).ReadToEndAsync();
                return content;
            }
        }
    }
}
