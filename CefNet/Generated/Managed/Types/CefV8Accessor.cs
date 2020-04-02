﻿// --------------------------------------------------------------------------------------------
// Copyright (c) 2019 The CefNet Authors. All rights reserved.
// Licensed under the MIT license.
// See the licence file in the project root for full license information.
// --------------------------------------------------------------------------------------------
// Generated by CefGen
// Source: Generated/Native/Types/cef_v8accessor_t.cs
// --------------------------------------------------------------------------------------------﻿
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
// --------------------------------------------------------------------------------------------

#pragma warning disable 0169, 1591, 1573

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using CefNet.WinApi;
using CefNet.CApi;
using CefNet.Internal;

namespace CefNet
{
	/// <summary>
	/// Structure that should be implemented to handle V8 accessor calls. Accessor
	/// identifiers are registered by calling cef_v8value_t::set_value(). The
	/// functions of this structure will be called on the thread associated with the
	/// V8 accessor.
	/// </summary>
	/// <remarks>
	/// Role: Handler
	/// </remarks>
	public unsafe partial class CefV8Accessor : CefBaseRefCounted<cef_v8accessor_t>, ICefV8AccessorPrivate
	{
		private static readonly GetDelegate fnGet = GetImpl;

		private static readonly SetDelegate fnSet = SetImpl;

		internal static unsafe CefV8Accessor Create(IntPtr instance)
		{
			return new CefV8Accessor((cef_v8accessor_t*)instance);
		}

		public CefV8Accessor()
		{
			cef_v8accessor_t* self = this.NativeInstance;
			self->get = (void*)Marshal.GetFunctionPointerForDelegate(fnGet);
			self->set = (void*)Marshal.GetFunctionPointerForDelegate(fnSet);
		}

		public CefV8Accessor(cef_v8accessor_t* instance)
			: base((cef_base_ref_counted_t*)instance)
		{
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefV8AccessorPrivate.AvoidGet();

		/// <summary>
		/// Handle retrieval the accessor value identified by |name|. |object| is the
		/// receiver (&apos;this&apos; object) of the accessor. If retrieval succeeds set
		/// |retval| to the return value. If retrieval fails set |exception| to the
		/// exception that will be thrown. Return true (1) if accessor retrieval was
		/// handled.
		/// </summary>
		public unsafe virtual bool Get(string name, CefV8Value @object, ref CefV8Value retval, ref string exception)
		{
			return default;
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate int GetDelegate(cef_v8accessor_t* self, cef_string_t* name, cef_v8value_t* @object, cef_v8value_t** retval, cef_string_t* exception);

		// int (*)(_cef_v8accessor_t* self, const cef_string_t* name, _cef_v8value_t* object, _cef_v8value_t** retval, cef_string_t* exception)*
		private static unsafe int GetImpl(cef_v8accessor_t* self, cef_string_t* name, cef_v8value_t* @object, cef_v8value_t** retval, cef_string_t* exception)
		{
			var instance = GetInstance((IntPtr)self) as CefV8Accessor;
			if (instance == null || ((ICefV8AccessorPrivate)instance).AvoidGet())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)@object);
				return default;
			}
			CefV8Value obj_retval = CefV8Value.Wrap(CefV8Value.Create, *retval);
			string s_exception = CefString.Read(exception);
			string s_orig_exception = s_exception;
			int rv = instance.Get(CefString.Read(name), CefV8Value.Wrap(CefV8Value.Create, @object), ref obj_retval, ref s_exception) ? 1 : 0;
			*retval = (obj_retval != null) ? obj_retval.GetNativeInstance() : null;
			if (s_exception != s_orig_exception)
				CefString.Replace(exception, s_exception);
			return rv;
		}

		[MethodImpl(MethodImplOptions.ForwardRef)]
		extern bool ICefV8AccessorPrivate.AvoidSet();

		/// <summary>
		/// Handle assignment of the accessor value identified by |name|. |object| is
		/// the receiver (&apos;this&apos; object) of the accessor. |value| is the new value
		/// being assigned to the accessor. If assignment fails set |exception| to the
		/// exception that will be thrown. Return true (1) if accessor assignment was
		/// handled.
		/// </summary>
		public unsafe virtual bool Set(string name, CefV8Value @object, CefV8Value value, ref string exception)
		{
			return default;
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		private unsafe delegate int SetDelegate(cef_v8accessor_t* self, cef_string_t* name, cef_v8value_t* @object, cef_v8value_t* value, cef_string_t* exception);

		// int (*)(_cef_v8accessor_t* self, const cef_string_t* name, _cef_v8value_t* object, _cef_v8value_t* value, cef_string_t* exception)*
		private static unsafe int SetImpl(cef_v8accessor_t* self, cef_string_t* name, cef_v8value_t* @object, cef_v8value_t* value, cef_string_t* exception)
		{
			var instance = GetInstance((IntPtr)self) as CefV8Accessor;
			if (instance == null || ((ICefV8AccessorPrivate)instance).AvoidSet())
			{
				ReleaseIfNonNull((cef_base_ref_counted_t*)@object);
				ReleaseIfNonNull((cef_base_ref_counted_t*)value);
				return default;
			}
			string s_exception = CefString.Read(exception);
			string s_orig_exception = s_exception;
			int rv = instance.Set(CefString.Read(name), CefV8Value.Wrap(CefV8Value.Create, @object), CefV8Value.Wrap(CefV8Value.Create, value), ref s_exception) ? 1 : 0;
			if (s_exception != s_orig_exception)
				CefString.Replace(exception, s_exception);
			return rv;
		}
	}
}
