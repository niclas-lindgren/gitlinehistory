using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLineHistory
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(IntraTextAdornmentTag))]
    internal class GitChangesAdornmentTaggerProvider : ITaggerProvider
    {
        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            // Get the adornment layer for the view.
            ITextView textView = TextViewFromBuffer(buffer);

            if (textView == null)
            {
                return null;
            }

            // Create a single tagger for each view/buffer pair.
            Func<GitChangesAdornmentTagger> taggerFactory = () => new GitChangesAdornmentTagger(textView, buffer);
            return buffer.Properties.GetOrCreateSingletonProperty(taggerFactory) as ITagger<T>;
        }

        private static ITextView TextViewFromBuffer(ITextBuffer buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            ITextView textView = null;
            var textViews = buffer.Properties.PropertyList.Where(p => p.Value is ITextView).Select(p => p.Value as ITextView);

            if (textViews.Any())
            {
                textView = textViews.First();
            }

            return textView;
        }
    }
}
