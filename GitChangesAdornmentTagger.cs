using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLineHistory
{
    internal class GitChangesAdornmentTagger : ITagger<IntraTextAdornmentTag>
    {
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        private readonly ITextView _view;
        private readonly ITextBuffer _buffer;

        public GitChangesAdornmentTagger(ITextView view, ITextBuffer buffer)
        {
            _view = view;
            _buffer = buffer;
        }

        public IEnumerable<ITagSpan<IntraTextAdornmentTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            // TODO: Implement the logic to provide adornment tags based on the spans
            yield break;
        }
    }
}
