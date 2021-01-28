using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input.TextInput;
using Avalonia.VisualTree;

namespace AvaloniaApp
{

	class ImClientStub : ITextInputMethodClient
	{
		private readonly Control _control;

		public ImClientStub(Control control)
		{
			_control = control;
			_control.GetObservable(Visual.BoundsProperty).Subscribe(_ =>
			{
				CursorRectangleChanged?.Invoke(this, EventArgs.Empty);
			});
		}

		public void SetPreeditText(string text)
		{

		}

		public Rect CursorRectangle => new Rect(_control.Bounds.Width / 2, _control.Bounds.Height - 1, 1, 1);
		public IVisual TextViewVisual => _control;
		public bool SupportsPreedit => false;
		public bool SupportsSurroundingText => false;
		public TextInputMethodSurroundingText SurroundingText => default;
		public string TextBeforeCursor => "";
		public string TextAfterCursor => "";
		public event EventHandler CursorRectangleChanged;
		public event EventHandler TextViewVisualChanged;
		public event EventHandler SurroundingTextChanged;

	}

}