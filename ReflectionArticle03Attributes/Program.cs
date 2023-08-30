namespace ReflectionArticle03Attributes
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Custom attribute to represent metadata about a class or method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// Gets the description associated with the class or method.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">The description text.</param>
        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }

    /// <summary>
    /// Represents a document processing service.
    /// </summary>
    [Description("This class provides functionalities for processing documents.")]
    class DocumentProcessor
    {
        /// <summary>
        /// Converts the input document to a different format.
        /// </summary>
        /// <param name="inputPath">The path to the input document.</param>
        /// <param name="outputPath">The path to the output document.</param>
        [Description("Converts the input document to a different format.")]
        public void ConvertDocument(string inputPath, string outputPath)
        {
            Console.WriteLine($"Converting document from {inputPath} to {outputPath}.");
            // Perform the document conversion logic here
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Getting the type of the class
            Type type = typeof(DocumentProcessor);

            // Retrieve attributes applied to the class
            object[] classAttributes = type.GetCustomAttributes(true);
            foreach (var attribute in classAttributes)
            {
                if (attribute is DescriptionAttribute descriptionAttribute)
                {
                    Console.WriteLine($"Class Description: {descriptionAttribute.Description}");
                }
            }

            // Getting the method information
            MethodInfo methodInfo = type.GetMethod("ConvertDocument");

            // Retrieve attributes applied to the method
            object[] methodAttributes = methodInfo.GetCustomAttributes(true);
            foreach (var attribute in methodAttributes)
            {
                if (attribute is DescriptionAttribute descriptionAttribute)
                {
                    Console.WriteLine($"Method Description: {descriptionAttribute.Description}");
                }
            }

            // Simulating invoking the method
            var instance = Activator.CreateInstance(type) as DocumentProcessor;
            instance.ConvertDocument("input.docx", "output.pdf");
        }
    }

}
