using LibGit2Sharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitLineHistory
{
    internal static class GitHelper
    {
        public static List<LineChange> GetLineChanges(string repositoryPath, string filePath)
        {
            var lineChanges = new List<LineChange>();

            using (var repo = new Repository(repositoryPath))
            {
                var fileRelativePath = filePath.Replace(repositoryPath, string.Empty).TrimStart(Path.DirectorySeparatorChar);
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
                var patchEntry = patch[fileRelativePath];

                foreach (var hunk in patchEntry.)
                {
                    var lineChange = new LineChange
                    {
                        LineNumber = contentChange.NewLineNumber,
                        ChangeKind = contentChange.Type
                    };

                    lineChanges.Add(lineChange);
                }
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
