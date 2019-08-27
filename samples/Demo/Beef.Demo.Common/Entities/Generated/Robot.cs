/*
 * This file is automatically generated; any changes will be lost. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Represents the Robot entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Robot : EntityBase, IGuidIdentifier, IETag, IChangeLog
    {
        #region PropertyNames
      
        /// <summary>
        /// Represents the <see cref="Id"/> property name.
        /// </summary>
        public const string Property_Id = nameof(Id);

        /// <summary>
        /// Represents the <see cref="ModelNo"/> property name.
        /// </summary>
        public const string Property_ModelNo = nameof(ModelNo);

        /// <summary>
        /// Represents the <see cref="SerialNo"/> property name.
        /// </summary>
        public const string Property_SerialNo = nameof(SerialNo);

        /// <summary>
        /// Represents the <see cref="EyeColor"/> property name.
        /// </summary>
        public const string Property_EyeColor = nameof(EyeColor);

        /// <summary>
        /// Represents the <see cref="PowerSource"/> property name.
        /// </summary>
        public const string Property_PowerSource = nameof(PowerSource);

        /// <summary>
        /// Represents the <see cref="ETag"/> property name.
        /// </summary>
        public const string Property_ETag = nameof(ETag);

        /// <summary>
        /// Represents the <see cref="ChangeLog"/> property name.
        /// </summary>
        public const string Property_ChangeLog = nameof(ChangeLog);

        #endregion

        #region Privates

        private Guid _id;
        private string _modelNo;
        private string _serialNo;
        private string _eyeColorSid;
        private string _powerSourceSid;
        private string _eTag;
        private ChangeLog _changeLog;

        #endregion

        #region Constructor
      
        /// <summary>
        /// Initializes a new instance of the <see cref="Robot"/> class.
        /// </summary>
        public Robot()
        {
            this.RobotConstructor();
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="Robot"/> identifier.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Identifier")]
        public Guid Id
        {
            get { return this._id; }
            set { SetValue<Guid>(ref this._id, value, false, false, Property_Id); }
        }

        /// <summary>
        /// Gets or sets the Model number.
        /// </summary>
        [JsonProperty("modelNo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Model No")]
        public string ModelNo
        {
            get { return this._modelNo; }
            set { SetValue(ref this._modelNo, value, false, StringTrim.End, StringTransform.EmptyToNull, Property_ModelNo); }
        }

        /// <summary>
        /// Gets or sets the Unique serial number.
        /// </summary>
        [JsonProperty("serialNo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Serial No")]
        public string SerialNo
        {
            get { return this._serialNo; }
            set { SetValue(ref this._serialNo, value, false, StringTrim.End, StringTransform.EmptyToNull, Property_SerialNo); }
        }

        /// <summary>
        /// Gets or sets the <see cref="EyeColor"/> using the underlying Serialization Identifier (SID).
        /// </summary>
        [JsonProperty("eyeColor", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Eye Color")]
        public string EyeColorSid
        {
            get { return this._eyeColorSid; }
            set { SetValue(ref this._eyeColorSid, value, false, StringTrim.End, StringTransform.EmptyToNull, Property_EyeColor); }
        }

        /// <summary>
        /// Gets or sets the Eye Color (see <see cref="RefDataNamespace.EyeColor"/>).
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Display(Name="Eye Color")]
        public RefDataNamespace.EyeColor EyeColor
        {
            get { return this._eyeColorSid; }
            set { SetValue<string>(ref this._eyeColorSid, value, false, false, Property_EyeColor); }
        }

        /// <summary>
        /// Gets or sets the <see cref="PowerSource"/> using the underlying Serialization Identifier (SID).
        /// </summary>
        [JsonProperty("powerSource", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Power Source")]
        public string PowerSourceSid
        {
            get { return this._powerSourceSid; }
            set { SetValue(ref this._powerSourceSid, value, false, StringTrim.End, StringTransform.EmptyToNull, Property_PowerSource); }
        }

        /// <summary>
        /// Gets or sets the Power Source (see <see cref="RefDataNamespace.PowerSource"/>).
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Display(Name="Power Source")]
        public RefDataNamespace.PowerSource PowerSource
        {
            get { return this._powerSourceSid; }
            set { SetValue<string>(ref this._powerSourceSid, value, false, false, Property_PowerSource); }
        }

        /// <summary>
        /// Gets or sets the ETag.
        /// </summary>
        [JsonProperty("_etag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="ETag")]
        public string ETag
        {
            get { return this._eTag; }
            set { SetValue(ref this._eTag, value, false, StringTrim.End, StringTransform.EmptyToNull, Property_ETag); }
        }

        /// <summary>
        /// Gets or sets the Change Log (see <see cref="ChangeLog"/>).
        /// </summary>
        [JsonProperty("changeLog", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Change Log")]
        public ChangeLog ChangeLog
        {
            get { return this._changeLog; }
            set { SetValue<ChangeLog>(ref this._changeLog, value, false, false, Property_ChangeLog); }
        }

        #endregion

        #region UniqueKey
      
        /// <summary>
        /// Indicates whether the <see cref="Robot"/> has a <see cref="UniqueKey"/> value.
        /// </summary>
        public override bool HasUniqueKey
        {
            get { return true; }
        }
        
        /// <summary>
        /// Gets the list of property names that represent the unique key.
        /// </summary>
        public override string[] UniqueKeyProperties => new string[] { Property_Id };
        
        /// <summary>
        /// Creates the <see cref="UniqueKey"/>.
        /// </summary>
        /// <returns>The <see cref="Beef.Entities.UniqueKey"/>.</returns>
        /// <param name="id">The <see cref="Id"/>.</param>
        public static UniqueKey CreateUniqueKey(Guid id)
        {
            return new UniqueKey(id);
        }
          
        /// <summary>
        /// Gets the <see cref="UniqueKey"/>.
        /// </summary>
        /// <remarks>
        /// The <b>UniqueKey</b> key consists of the following property(s): <see cref="Id"/>.
        /// </remarks>
        public override UniqueKey UniqueKey
        {
            get { return new UniqueKey(this.Id); }
        }

        #endregion

        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="Robot"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Robot"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<Robot>(from);
            CopyFrom((Robot)fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="Robot"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Robot"/> to copy from.</param>
        public void CopyFrom(Robot from)
        {
            CopyFrom((EntityBase)from);
            this.Id = from.Id;
            this.ModelNo = from.ModelNo;
            this.SerialNo = from.SerialNo;
            this.EyeColor = from.EyeColor;
            this.PowerSource = from.PowerSource;
            this.ETag = from.ETag;
            this.ChangeLog = from.ChangeLog;

            this.OnAfterCopyFrom(from);
        }
    
        #endregion
        
        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="Robot"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="Robot"/>.</returns>
        public override object Clone()
        {
            var clone = new Robot();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="Robot"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            this.Id = Cleaner.Clean<Guid>(this.Id);
            this.ModelNo = Cleaner.Clean(this.ModelNo, StringTrim.End, StringTransform.EmptyToNull);
            this.SerialNo = Cleaner.Clean(this.SerialNo, StringTrim.End, StringTransform.EmptyToNull);
            this.EyeColor = Cleaner.Clean<RefDataNamespace.EyeColor>(this.EyeColor);
            this.PowerSource = Cleaner.Clean<RefDataNamespace.PowerSource>(this.PowerSource);
            this.ETag = Cleaner.Clean(this.ETag, StringTrim.End, StringTransform.EmptyToNull);
            this.ChangeLog = Cleaner.Clean<ChangeLog>(this.ChangeLog);

            this.OnAfterCleanUp();
        }
    
        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get
            {
                return Cleaner.IsInitial(this.Id)
                    && Cleaner.IsInitial(this.ModelNo)
                    && Cleaner.IsInitial(this.SerialNo)
                    && Cleaner.IsInitial(this.EyeColor)
                    && Cleaner.IsInitial(this.PowerSource)
                    && Cleaner.IsInitial(this.ETag)
                    && Cleaner.IsInitial(this.ChangeLog);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void RobotConstructor();

        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(Robot from);

        #endregion
    } 

    /// <summary>
    /// Represents a <see cref="Robot"/> collection.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public partial class RobotCollection : EntityBaseCollection<Robot>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RobotCollection"/> class.
        /// </summary>
        public RobotCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotCollection"/> class with an entity range.
        /// </summary>
        /// <param name="entities">The <see cref="Robot"/> entities.</param>
        public RobotCollection(IEnumerable<Robot> entities)
        {
            AddRange(entities);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="RobotCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="RobotCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new RobotCollection();
            foreach (Robot item in this)
            {
                clone.Add((Robot)item.Clone());
            }
                
            return clone;
        }
        
        #endregion

        #region Operator

        /// <summary>
        /// An implicit cast from a <see cref="RobotCollectionResult"/> to a <see cref="RobotCollection"/>.
        /// </summary>
        /// <param name="result">The <see cref="RobotCollectionResult"/>.</param>
        /// <returns>The corresponding <see cref="RobotCollection"/>.</returns>
        public static implicit operator RobotCollection(RobotCollectionResult result)
        {
            return result?.Result;
        }

        #endregion
    }

    /// <summary>
    /// Represents a <see cref="Robot"/> collection result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Tightly coupled; OK.")]
    public class RobotCollectionResult : EntityCollectionResult<RobotCollection, Robot>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RobotCollectionResult"/> class.
        /// </summary>
        public RobotCollectionResult() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RobotCollectionResult"/> class with default <see cref="PagingArgs"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public RobotCollectionResult(PagingArgs paging) : base(paging) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public RobotCollectionResult(IEnumerable<Robot> collection, PagingArgs paging = null) : base(paging)
        {
            this.Result.AddRange(collection);
        }
        
        /// <summary>
        /// Creates a deep copy of the <see cref="RobotCollectionResult"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="RobotCollectionResult"/>.</returns>
        public override object Clone()
        {
            var clone = new RobotCollectionResult();
            clone.CopyFrom(this);
            return clone;
        }
    }
}
