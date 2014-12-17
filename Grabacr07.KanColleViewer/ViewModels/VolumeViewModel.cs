﻿using Grabacr07.KanColleViewer.Models;
using Livet;
using Livet.EventListeners;
using System;
using System.Diagnostics;

namespace Grabacr07.KanColleViewer.ViewModels
{
	public class VolumeViewModel : ViewModel
	{
		private Volume volume;

		#region IsMute 変更通知プロパティ

		private bool _IsMute;

		public bool IsMute
		{
			get { return this._IsMute; }
			set
			{
				if (this._IsMute != value)
				{
					this._IsMute = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public VolumeViewModel()
		{
			this.CreateVolumeInstanceIfNull();
		}

		public void ToggleMute()
		{
			if (this.CreateVolumeInstanceIfNull())
			{
				this.volume.ToggleMute();
			}
		}

		public bool IsExistSoundDevice()
		{
			if (this.CreateVolumeInstanceIfNull())
			{
				return true;
			}
			else return false;
		}

		private bool CreateVolumeInstanceIfNull()
		{
			if (this.volume == null)
			{
				try
				{
					this.volume = Volume.GetInstance();
					this.CompositeDisposable.Add(new PropertyChangedEventListener(this.volume)
					{
						{ "IsMute", (sender, args) => this.IsMute = this.volume.IsMute },
					});
					this.IsMute = this.volume.IsMute;
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex);
					return false;
				}
			}

			return true;
		}
	}
}
