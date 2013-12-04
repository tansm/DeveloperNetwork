using System;

namespace DeveloperNetwork.Common.Library {
    /// <summary>
    /// 描述一个树中的一个节点。
    /// </summary>
    public interface ITreeItem {
        /// <summary>
        /// 返回此节点的标题，用于显示到树节点上作为标题。
        /// </summary>
        string Caption { get; }

        /// <summary>
        /// 返回此节点应该显示的图像键。
        /// </summary>
        string ImageKey { get; }

        /// <summary>
        /// 返回当点击此节点时，应该链接到那个页面。
        /// </summary>
        string Href { get; }
    }
}
