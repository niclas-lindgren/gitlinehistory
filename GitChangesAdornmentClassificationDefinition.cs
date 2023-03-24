using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace GitLineHistory
{
    /// <summary>
    /// Classification type definition export for GitChangesAdornment
    /// </summary>
    internal static class GitChangesAdornmentClassificationDefinition
    {
        // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

        /// <summary>
        /// Defines the "GitChangesAdornment" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("GitChangesAdornment")]
        private static ClassificationTypeDefinition typeDefinition;

#pragma warning restore 169
    }
}
