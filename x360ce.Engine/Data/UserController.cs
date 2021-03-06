﻿using JocysCom.ClassLibrary.IO;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;

namespace x360ce.Engine.Data
{
	public partial class UserController
	{


		public void LoadInstance(DeviceInstance ins)
		{
			ForceFeedbackDriverGuid = ins.ForceFeedbackDriverGuid;
			InstanceGuid = ins.InstanceGuid;
			InstanceName = ins.InstanceName;
			ProductGuid = ins.ProductGuid;
			ProductName = ins.ProductName;
			Usage = (int)ins.Usage;
			UsagePage = (int)ins.UsagePage;
		}

		public void LoadCapabilities(Capabilities cap)
		{
			CapAxeCount = cap.AxeCount;
			CapButtonCount = cap.ButtonCount;
			CapDriverVersion = cap.DriverVersion;
			CapFirmwareRevision = cap.FirmwareRevision;
			CapFlags = (int)cap.Flags;
			CapForceFeedbackMinimumTimeResolution = cap.ForceFeedbackMinimumTimeResolution;
			CapForceFeedbackSamplePeriod = cap.ForceFeedbackSamplePeriod;
			CapHardwareRevision = cap.HardwareRevision;
			CapPovCount = cap.PovCount;
			CapIsHumanInterfaceDevice = cap.IsHumanInterfaceDevice;
			CapSubtype = cap.Subtype;
			CapType = (int)cap.Type;
		}

		public void LoadHidDeviceInfo(DeviceInfo info)
		{
			HidManufacturer = info.Manufacturer;
			HidVendorId = (int)info.VendorId;
			HidProductId = (int)info.ProductId;
			HidRevision = (int)info.Revision;
			HidDescription = info.Description;
			HidDeviceId = info.DeviceId;
			HidDevicePath = info.DevicePath;
			HidParentDeviceId = info.ParentDeviceId;
			HidClassGuid = info.ClassGuid;
			HidClassDescription = info.ClassDescription;
		}

		public void LoadDevDeviceInfo(DeviceInfo info)
		{
			DevManufacturer = info.Manufacturer;
			DevVendorId = (int)info.VendorId;
			DevProductId = (int)info.ProductId;
			DevRevision = (int)info.Revision;
			DevDescription = info.Description;
			DevDeviceId = info.DeviceId;
			DevDevicePath = info.DevicePath;
			DevParentDeviceId = info.ParentDeviceId;
			DevClassGuid = info.ClassGuid;
			DevClassDescription = info.ClassDescription;
		}


		#region Ignored Properties

		/// <summary>DInput Device State.</summary>
		[XmlIgnore]
		public Joystick Device;

		[XmlIgnore]
		public bool IsOnline
		{
			get { return _IsOnline; }
			set { _IsOnline = value; ReportPropertyChanged(x => x.IsOnline); }
		}
		bool _IsOnline;

		[XmlIgnore]
		public string InstanceId
		{
			get
			{
				return EngineHelper.GetID(InstanceGuid);
			}
		}

		#endregion

		#region INotifyPropertyChanged

		/// <summary>
		/// Use: ReportPropertyChanged(x => x.PropertyName);
		/// </summary>
		void ReportPropertyChanged(Expression<Func<UserController, object>> selector)
		{
			var body = (MemberExpression)((UnaryExpression)selector.Body).Operand;
			var name = body.Member.Name;
			ReportPropertyChanged(name);
		}

		#endregion
	}
}
