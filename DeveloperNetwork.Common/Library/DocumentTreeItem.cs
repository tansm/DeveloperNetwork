using System;

namespace DeveloperNetwork.Common.Library{

    public class DocumentTreeItem : ITreeItem {
        private readonly StringZip _stringZip;

        protected DocumentTreeItem(StringZip stringZip) {
            if (stringZip != null) {
                ExceptionHelper.ThrowArgumentNullException("stringZip");
            }
            this._stringZip = stringZip;
        }

        protected StringZip StringZip {
            get { return this._stringZip; }
        }

        private int[] _captionData;
        public string Caption {
            get { return this.StringZip.UnzipString(this._captionData); }
            set { this._captionData = this.StringZip.ZipString(value); }
        }

        private int[] _hrefData;
        public string Href {
            get { return this.StringZip.UnzipString(this._hrefData); }
            set { this._hrefData = this.StringZip.ZipString(value); }
        }

        public virtual string ImageKey {
            get { return "doc"; }
        }
    }
}