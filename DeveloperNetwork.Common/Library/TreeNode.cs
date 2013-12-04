
namespace DeveloperNetwork.Common.Library {

    /// <summary>
    /// 树结构的一个节点对象。
    /// </summary>
    public sealed partial class TreeNode<T> {

        private TreeNodeCollection _childNodes;
        /// <summary>
        /// 返回所有的子节点。
        /// </summary>
        public TreeNodeCollection ChildNodes {
            get {
                if (this._childNodes == null) {
                    this._childNodes = new TreeNodeCollection(this);
                }
                return this._childNodes;
            }
        }

        private TreeNode<T> _parent;
        /// <summary>
        /// 如果节点存在父节点，返回其父节点。
        /// </summary>
        public TreeNode<T> Parent {
            get { return _parent; }
        }
        
        private T _data;
        /// <summary>
        /// 返回/设置关联的数据。
        /// </summary>
        public T Data {
            get { return _data; }
            set { _data = value; }
        }
    }
}
