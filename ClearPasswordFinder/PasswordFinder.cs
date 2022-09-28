namespace ClearPasswordFinder;

public class PasswordFinder
{
    private static string[] Patterns = { "-P", "pwd", "password", "pass", "secret", "key", "pin"};
    // Process all files in the directory passed in, recurse on any directories
    // that are found, and process the files they contain.
    public static void ProcessDirectory(string targetDirectory)
    {
        // Process the list of files found in the directory.
        string [] fileEntries = Directory.GetFiles(targetDirectory);
        foreach(string fileName in fileEntries)
            ProcessFile(fileName);

        // Recurse into subdirectories of this directory.
        string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach(string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory);
    }
    //No comment2
    public static void ProcessFile(string path)
    {
        var foundOccurence = false;
        var linesOfWords = File.ReadLines(path).Select(item => item.Split(" ")).ToList();
        linesOfWords.ForEach(line => line.ToList().ForEach(word =>
        {
            if (Patterns.Contains(word))
            {
                foundOccurence = true;
            }
        }));
        if(foundOccurence)
            Console.WriteLine("Processed file '{0}' and found occurence: {1}.", path, foundOccurence);	
    }
}