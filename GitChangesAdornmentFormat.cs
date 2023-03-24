using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace GitLineHistory
{
    /// <summary>
    /// Defines an editor format for the GitChangesAdornment type
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "GitChangesAdornment")]
    [Name("GitChangesAdornment")]
    [UserVisible(true)] // This should be visible to the end user
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
    internal sealed class GitChangesAdornmentFormat : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GitChangesAdornmentFormat"/> class.
        /// </summary>
        public GitChangesAdornmentFormat()
        {
            this.DisplayName = "Git linechanges"; // Human readable version of the name
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }
}
