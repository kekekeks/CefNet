using Avalonia.Interactivity;
using CefNet.Avalonia;
using CefNet.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Avalonia;
using Avalonia.Input;
using Avalonia.Input.TextInput;
using Avalonia.VisualTree;

namespace AvaloniaApp
{
	sealed class CustomWebView : WebView
	{
		public static RoutedEvent<FullscreenModeChangeEventArgs> FullscreenEvent = RoutedEvent.Register<WebView, FullscreenModeChangeEventArgs>("Fullscreen", RoutingStrategies.Bubble);

		public event EventHandler<FullscreenModeChangeEventArgs> Fullscreen
		{
			add { AddHandler(FullscreenEvent, value); }
			remove { RemoveHandler(FullscreenEvent, value); }
		}

		private ImClientStub _im;

		public CustomWebView() : this(null)
		{

		}

		public CustomWebView(WebView opener)
			: base(opener)
		{
			_im = new ImClientStub(this);

			AddHandler(TextInputMethodClientRequestedEvent, (_, e) =>
			{
				Console.WriteLine("IME requested");
				e.Client = _im;
			});
		}

		protected override WebViewGlue CreateWebViewGlue()
		{
			return new CustomWebViewGlue(this);
		}



		internal void RaiseFullscreenModeChange(bool fullscreen)
		{
			RaiseCrossThreadEvent(OnFullScreenModeChange, new FullscreenModeChangeEventArgs(this, fullscreen), false);
		}

		private void OnFullScreenModeChange(FullscreenModeChangeEventArgs e)
		{
			RaiseEvent(e);
		}


	}
}
