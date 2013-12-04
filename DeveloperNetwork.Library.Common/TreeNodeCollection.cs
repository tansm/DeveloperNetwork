using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperNetwork.Common;

namespace DeveloperNetwork.Library.Common {

    partial class TreeNode<T> {

        public sealed class TreeNodeCollection : Collection<TreeNode<T>> {
            private TreeNode<T> _owner;

            internal TreeNodeCollection(TreeNode<T> owner) {
                this._owner = owner;
            }

            protected override void InsertItem(int index, TreeNode<T> item) {
                if (item == null) {
                    ExceptionHelper.ThrowArgumentNullException("item");
                }

                if (item._parent != null) {
                    ExceptionHelper.ThrowArgumentOutOfRangeException("item");
                } 

                base.InsertItem(index, item);
                item._parent = this._owner;
            }

            protected override void RemoveItem(int index) {
                var item = base.Items[index];

                base.RemoveItem(index);
                item._parent = null;
            }

            protected override void ClearItems() {
                foreach (var item in base.Items) {
                    item._parent = null;
                }
                base.ClearItems();
            }

            protected override void SetItem(int index, TreeNode<T> item) {
                if (item == null) {
                    ExceptionHelper.ThrowArgumentNullException("item");
                }
                if (item._parent != null) {
                    ExceptionHelper.ThrowArgumentOutOfRangeException("item");
                } 

                var oldItem = base.Items[index];
                oldItem._parent = null;

                base.SetItem(index, item);
                item._parent = this._owner;
            }
        }
    }
}
