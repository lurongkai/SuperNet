using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.UI.Converter
{
    public class ConverterPresenter
    {
        private IConverterView _view;

        public ConverterPresenter() { }
        public ConverterPresenter(IConverterView view) {
            _view = view;
        }
    }
}
