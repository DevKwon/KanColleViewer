﻿using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Livet.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grabacr07.KanColleViewer.ViewModels.Catalogs
{
	public abstract class ShipCatalogFilter : NotificationObject
	{
		private readonly Action action;

		public abstract bool Predicate(Ship ship);

		protected ShipCatalogFilter(Action updateAction)
		{
			this.action = updateAction;
		}

		protected void Update()
		{
			if (this.action != null) this.action();
		}
	}

	public class ShipLevelFilter : ShipCatalogFilter
	{
		#region Both 変更通知プロパティ

		private bool _Both;

		public bool Both
		{
			get { return this._Both; }
			set
			{
				if (this._Both != value)
				{
					this._Both = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region Level1 変更通知プロパティ

		private bool _Level1;

		public bool Level1
		{
			get { return this._Level1; }
			set
			{
				if (this._Level1 != value)
				{
					this._Level1 = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region Level2OrMore 変更通知プロパティ

		private bool _Level2OrMore;

		public bool Level2OrMore
		{
			get { return this._Level2OrMore; }
			set
			{
				if (this._Level2OrMore != value)
				{
					this._Level2OrMore = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		public ShipLevelFilter(Action updateAction)
			: base(updateAction)
		{
			this._Level2OrMore = true;
		}

		public override bool Predicate(Ship ship)
		{
			if (this.Both) return true;
			if (this.Level2OrMore && ship.Level >= 2) return true;
			if (this.Level1 && ship.Level == 1) return true;

			return false;
		}
	}

	public class ShipLockFilter : ShipCatalogFilter
	{
		#region Both 変更通知プロパティ

		private bool _Both;

		public bool Both
		{
			get { return this._Both; }
			set
			{
				if (this._Both != value)
				{
					this._Both = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region Locked 変更通知プロパティ

		private bool _Locked;

		public bool Locked
		{
			get { return this._Locked; }
			set
			{
				if (this._Locked != value)
				{
					this._Locked = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region Unlocked 変更通知プロパティ

		private bool _Unlocked;

		public bool Unlocked
		{
			get { return this._Unlocked; }
			set
			{
				if (this._Unlocked != value)
				{
					this._Unlocked = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		public ShipLockFilter(Action updateAction)
			: base(updateAction)
		{
			this._Locked = true;
		}

		public override bool Predicate(Ship ship)
		{
			if (this.Both) return true;
			if (this.Locked && ship.IsLocked) return true;
			if (this.Unlocked && !ship.IsLocked) return true;

			return false;
		}
	}

	public class ShipSpeedFilter : ShipCatalogFilter
	{
		#region Both 変更通知プロパティ

		private bool _Both;

		public bool Both
		{
			get { return this._Both; }
			set
			{
				if (this._Both != value)
				{
					this._Both = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region Fast 変更通知プロパティ

		private bool _Fast;

		public bool Fast
		{
			get { return this._Fast; }
			set
			{
				if (this._Fast != value)
				{
					this._Fast = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region Low 変更通知プロパティ

		private bool _Low;

		public bool Low
		{
			get { return this._Low; }
			set
			{
				if (this._Low != value)
				{
					this._Low = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public ShipSpeedFilter(Action updateAction)
			: base(updateAction)
		{
			this._Both = true;
		}

		public override bool Predicate(Ship ship)
		{
			if (this.Both) return true;
			if (this.Fast && ship.Info.Speed == Speed.Fast) return true;
			if (this.Low && ship.Info.Speed == Speed.Low) return true;

			return false;
		}
	}

	public class ShipModernizeFilter : ShipCatalogFilter
	{
		#region Both 変更通知プロパティ

		private bool _Both;

		public bool Both
		{
			get { return this._Both; }
			set
			{
				if (this._Both != value)
				{
					this._Both = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region MaxModernized 変更通知プロパティ

		private bool _MaxModernized;

		public bool MaxModernized
		{
			get { return this._MaxModernized; }
			set
			{
				if (this._MaxModernized != value)
				{
					this._MaxModernized = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region NotMaxModernized 変更通知プロパティ

		private bool _NotMaxModernized;

		public bool NotMaxModernized
		{
			get { return this._NotMaxModernized; }
			set
			{
				if (this._NotMaxModernized != value)
				{
					this._NotMaxModernized = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		public ShipModernizeFilter(Action updateAction)
			: base(updateAction)
		{
			this._Both = true;
		}

		public override bool Predicate(Ship ship)
		{
			if (this.Both) return true;
			if (this.MaxModernized && ship.IsMaxModernized) return true;
			if (this.NotMaxModernized && !ship.IsMaxModernized) return true;

			return false;
		}
	}

	public class ShipRemodelingFilter : ShipCatalogFilter
	{
		#region Both 変更通知プロパティ

		private bool _Both;

		public bool Both
		{
			get { return this._Both; }
			set
			{
				if (this._Both != value)
				{
					this._Both = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region AlreadyRemodeling 変更通知プロパティ

		private bool _AlreadyRemodeling;

		public bool AlreadyRemodeling
		{
			get { return this._AlreadyRemodeling; }
			set
			{
				if (this._AlreadyRemodeling != value)
				{
					this._AlreadyRemodeling = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region NotAlreadyRemodeling 変更通知プロパティ

		private bool _NotAlreadyRemodeling;

		public bool NotAlreadyRemodeling
		{
			get { return this._NotAlreadyRemodeling; }
			set
			{
				if (this._NotAlreadyRemodeling != value)
				{
					this._NotAlreadyRemodeling = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		public ShipRemodelingFilter(Action updateAction)
			: base(updateAction)
		{
			this._Both = true;
		}

		public override bool Predicate(Ship ship)
		{
			if (this.Both) return true;
			if (this.AlreadyRemodeling && !ship.Info.NextRemodelingLevel.HasValue) return true;
			if (this.NotAlreadyRemodeling && ship.Info.NextRemodelingLevel.HasValue) return true;

			return false;
		}
	}

	public class ShipExpeditionFilter : ShipCatalogFilter
	{
		private HashSet<int> shipIds = new HashSet<int>();

		#region WithoutExpedition 変更通知プロパティ

		private bool _WithoutExpedition;

		public bool WithoutExpedition
		{
			get { return this._WithoutExpedition; }
			set
			{
				if (this._WithoutExpedition != value)
				{
					this._WithoutExpedition = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		public ShipExpeditionFilter(Action updateAction) : base(updateAction) { }

		public override bool Predicate(Ship ship)
		{
			return !this.WithoutExpedition || !this.shipIds.Contains(ship.Id);
		}

		public void SetFleets(MemberTable<Fleet> fleets)
		{
			if (fleets == null) return;

			this.shipIds = new HashSet<int>(fleets
				.Where(x => x.Value.Expedition.IsInExecution)
				.SelectMany(x => x.Value.Ships.Select(s => s.Id)));
		}
	}

	public class ShipSallyAreaFilter : ShipCatalogFilter
	{
		#region None 変更通知プロパティ

		private bool _None = true;

		public bool None
		{
			get { return this._None; }
			set
			{
				if (this._None != value)
				{
					this._None = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region FirstMap 変更通知プロパティ

		private bool _FirstMap = true;

		public bool FirstMap
		{
			get { return this._FirstMap; }
			set
			{
				if (this._FirstMap != value)
				{
					this._FirstMap = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region SecondMap 変更通知プロパティ

		private bool _SecondMap = true;

		public bool SecondMap
		{
			get { return this._SecondMap; }
			set
			{
				if (this._SecondMap != value)
				{
					this._SecondMap = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion

		#region ThirdMap 変更通知プロパティ

		private bool _ThirdMap = true;

		public bool ThirdMap
		{
			get { return this._ThirdMap; }
			set
			{
				if (this._ThirdMap != value)
				{
					this._ThirdMap = value;
					this.RaisePropertyChanged();
					this.Update();
				}
			}
		}

		#endregion


		public ShipSallyAreaFilter(Action updateAction) : base(updateAction) { }

		public override bool Predicate(Ship ship)
		{
			if (this.None && ship.SallyArea == 0) return true;
			if (this.FirstMap && ship.SallyArea == 1) return true;
			if (this.SecondMap && ship.SallyArea == 2) return true;
			if (this.ThirdMap && ship.SallyArea == 3) return true;

			return false;

			//return true;
		}
	}

	public class ShipNameSearchFilter : ShipCatalogFilter
	{
		#region SearchCommand コマンド

		private ViewModelCommand _SearchCommand;

		public ViewModelCommand SearchCommand
		{
			get
			{
				if (this._SearchCommand == null)
				{
					this._SearchCommand = new ViewModelCommand(this.Update);
				}
				return this._SearchCommand;
			}
		}

		#endregion

		#region NameString 変更通知プロパティ

		private string _NameString;

		public string NameString
		{
			get { return this._NameString; }
			set
			{
				if (this._NameString != value)
				{
					this._NameString = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public ShipNameSearchFilter(Action updateAction) : base(updateAction) { }

		public override bool Predicate(Ship ship)
		{
			if (this.NameString == null) return true;
			if (ship.Info.Name.Contains(this.NameString)) return true;
			return false;
		}
	}
	public class ShipNdockTimeFilter:ShipCatalogFilter
	{
		public ShipNdockTimeFilter(Action updateAction) : base(updateAction) { }

		public override bool Predicate(Ship ship)
		{
			if (ship.IsInRepairing) return false;
			if (ship.RepairTime != 0) return true;
			return false;
		}

	}
}
