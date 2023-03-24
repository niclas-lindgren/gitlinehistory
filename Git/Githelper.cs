using LibGit2Sharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitLineHistory
{
    public static class GitHelper
    {
        public static List<LineChange> GetLineChanges()
        {
            var lineChanges = new List<LineChange>();
           
            using (var repo = new Repository(Directory.GetCurrentDirectory()))
            {
                var headCommit = repo.Head.Tip;

                if (headCommit == null)
                {
                    return lineChanges;
                }

                var treeEntry = headCommit[repo.Head.CanonicalName]?.Target as Tree;

                if (treeEntry == null)
                {
                    return lineChanges;
                }

                var parentCommit = headCommit.Parents.FirstOrDefault();
                if (parentCommit == null)
                {
                    return lineChanges;
                }

                var oldTree = parentCommit.Tree;
                var newTree = headCommit.Tree;

                var patch = repo.Diff.Compare<Patch>(oldTree, newTree);

            }

            return lineChanges;
        }
    }

    public class LineChange
    {
        public int LineNumber { get; set; }
        public LineChangeKind ChangeKind { get; set; }
    }

    public enum LineChangeKind
    {
        Unchanged,
        Added,
        Deleted,
        Modified,
    }
}
