﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Beef.Data.OData
{
    /// <summary>
    /// Enables core <b>OData</b> property mapping capabilities.
    /// </summary>
    public interface IODataPropertyMapper : IPropertyMapperBase
    {
        /// <summary>
        /// Gets the source property value from a <see cref="JToken"/>.
        /// </summary>
        /// <param name="json">The <see cref="JToken"/>.</param>
        /// <returns>The source property value.</returns>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        object GetSrceValue(JToken json, OperationTypes operationType);

        /// <summary>
        /// Gets the destination value from the <paramref name="value"/> and applies the <see cref="IPropertyMapperBase.Converter"/> where specified.
        /// </summary>
        /// <param name="value">The source value.</param>
        /// <returns>The destination value equivalent.</returns>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        object GetDestValue(object value, OperationTypes operationType);

        /// <summary>
        /// Invokes the underlying <b>when</b> clause to determine whether the destination to source mapping should occur.
        /// </summary>
        /// <returns><c>true</c> indicates that the mapping should occur; otherwise, <c>false</c>.</returns>
        bool MapDestToSrceWhen();
    }

    /// <summary>
    /// Enables core <b>OData</b> property mapping capabilities.
    /// </summary>
    /// <typeparam name="TSrce">The source entity <see cref="Type"/>.</typeparam>
    public interface IODataPropertyMapper<TSrce> : IODataPropertyMapper, IPropertySrceMapper<TSrce> where TSrce : class
    {
        /// <summary>
        /// Sets the source property value from a <see cref="JToken"/>.
        /// </summary>
        /// <param name="value">The source value.</param>
        /// <param name="json">The <see cref="JToken"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        void SetSrceValue(TSrce value, JToken json, OperationTypes operationType);

        /// <summary>
        /// Sets (writes to) the destination <see cref="JToken"/> from the source property value.
        /// </summary>
        /// <param name="value">The source value.</param>
        /// <param name="json">The <see cref="JToken"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        void SetDestValue(TSrce value, JToken json, OperationTypes operationType);
    }

    /// <summary>
    /// Provides the <b>OData</b> property mapping capabilities.
    /// </summary>
    /// <typeparam name="TSrce">The source entity <see cref="Type"/>.</typeparam>
    /// <typeparam name="TSrceProperty">The source property <see cref="Type"/>.</typeparam>
    public class ODataPropertyMapper<TSrce, TSrceProperty> : PropertyMapperCustomBase<TSrce, TSrceProperty>, IODataPropertyMapper<TSrce>
        where TSrce : class
    {
        private Func<bool> _mapDestToSrceWhen;

        /// <summary>
        /// Initializes a new instance of the <see cref="ODataPropertyMapper{TSrce, TSrceProperty}"/> class.
        /// </summary>
        /// <param name="srcePropertyExpression">The <see cref="LambdaExpression"/> to reference the source entity property.</param>
        /// <param name="odataPropertyName">The <b>OData</b> property name (updates the <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}.DestPropertyName"/>).</param>
        /// <param name="operationTypes">The <see cref="Mapper.OperationTypes"/> selection to enable inclusion or exclusion of property (default to <see cref="OperationTypes.Any"/>).</param>
        public ODataPropertyMapper(Expression<Func<TSrce, TSrceProperty>> srcePropertyExpression, string odataPropertyName = null, OperationTypes operationTypes = OperationTypes.Any) 
            : base(srcePropertyExpression, odataPropertyName, operationTypes) { }

        /// <summary>
        /// Sets the unique key (enables fluent-style).
        /// </summary>
        /// <param name="autoGeneratedOnCreate">Indicates whether the destination property value is auto-generated on create (defaults to <c>true</c>).</param>
        /// <returns>The <see cref="ODataPropertyMapper{TSrce, TSrceProperty}"/>.</returns>
        public new ODataPropertyMapper<TSrce, TSrceProperty> SetUniqueKey(bool autoGeneratedOnCreate = true)
        {
            base.SetUniqueKey(autoGeneratedOnCreate);
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IPropertyMapperConverter{TSrceProperty, TDestProperty}"/> (used where a specific source and destination type conversion is required).
        /// </summary>
        /// <typeparam name="TDestProperty">The destination property <see cref="Type"/>.</typeparam>
        /// <param name="converter">The <see cref="IPropertyMapperConverter{TSrceProperty, TDestProperty}"/>.</param>
        /// <returns>The <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}"/>.</returns>
        public new ODataPropertyMapper<TSrce, TSrceProperty> SetConverter<TDestProperty>(IPropertyMapperConverter<TSrceProperty, TDestProperty> converter)
        {
            base.SetConverter(converter);
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IEntityMapperBase"/> to map complex types.
        /// </summary>
        /// <param name="mapper">The <see cref="IEntityMapperBase"/> (must be <see cref="IODataMapper"/>).</param>
        /// <returns>The <see cref="PropertyMapperCustomBase{TSrce, TSrceProperty}"/>.</returns>
        public new ODataPropertyMapper<TSrce, TSrceProperty> SetMapper(IEntityMapperBase mapper)
        {
            if (mapper != null && !(mapper is IODataMapper))
                throw new ArgumentException("Mapper must be instance of IODataMapper.", nameof(mapper));

            base.SetMapper(mapper);
            return this;
        }

        /// <summary>
        /// Defines a conditional clause which must be <c>true</c> when mapping from the source to the destination.
        /// </summary>
        /// <param name="predicate">A function to determine whether the property is to be mapped.</param>
        /// <returns>The <see cref="ODataPropertyMapper{TEntity, TProperty}"/>.</returns>
        public new ODataPropertyMapper<TSrce, TSrceProperty> MapSrceToDestWhen(Func<TSrce, bool> predicate)
        {
            return (ODataPropertyMapper<TSrce, TSrceProperty>)base.MapSrceToDestWhen(predicate);
        }

        /// <summary>
        /// Defines a conditional clause which must be <c>true</c> when mapping from the destination.
        /// </summary>
        /// <param name="predicate">A function to determine whether the property is to be mapped.</param>
        /// <returns>The <see cref="ODataPropertyMapper{TEntity, TProperty}"/>.</returns>
        public ODataPropertyMapper<TSrce, TSrceProperty> MapDestToSrceWhen(Func<bool> predicate)
        {
            _mapDestToSrceWhen = predicate;
            return this;
        }

        /// <summary>
        /// Invokes the underlying <b>when</b> clause to determine whether the destination to source mapping should occur.
        /// </summary>
        /// <returns><c>true</c> indicates that the mapping should occur; otherwise, <c>false</c>.</returns>
        bool IODataPropertyMapper.MapDestToSrceWhen()
        {
            return (_mapDestToSrceWhen == null) ? true : _mapDestToSrceWhen.Invoke();
        }

        /// <summary>
        /// Sets the source property value from a <see cref="JToken"/>.
        /// </summary>
        /// <param name="value">The source value.</param>
        /// <param name="json">The <see cref="JToken"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        public void SetSrceValue(TSrce value, JToken json, OperationTypes operationType)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            SetSrceValue(value, (TSrceProperty)((IODataPropertyMapper)this).GetSrceValue(json, operationType), operationType);
        }

        /// <summary>
        /// Gets the source property value from a <see cref="JToken"/>.
        /// </summary>
        /// <param name="json">The <see cref="JToken"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <returns>The source value.</returns>
        object IODataPropertyMapper.GetSrceValue(JToken json, OperationTypes operationType)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));

            if (Converter != null)
                return (TSrceProperty)Converter.ConvertToSrce(Cleaner.Clean(json.ToObject(Converter.DestType)));

            if (!IsSrceComplexType)
                return json.ToObject<TSrceProperty>();

            if (!json.HasValues)
                return null;

            var em = (IODataMapper)Mapper;
            if (SrceComplexTypeReflector.ComplexTypeCode == Reflection.ComplexTypeCode.Object)
                return (em == null) ? json.ToObject(SrceComplexTypeReflector.PropertyInfo.PropertyType) : em.MapFromOData(json, operationType);

            if (json.Type != JTokenType.Array)
                throw new MapperException($"Property '{SrcePropertyName}' has Type '{SrcePropertyType.Name}' and therefore expects a JTokenType.Array not JTokenType.{json.Type}.");

            if (em == null)
                return json.ToObject(SrceComplexTypeReflector.PropertyInfo.PropertyType);

            var vals = new List<Object>();
            foreach (var jao in json.Children<JObject>())
            {
                vals.Add(em.MapFromOData(jao, operationType));
            }

            return SrceComplexTypeReflector.CreateValue(vals);
        }

        /// <summary>
        /// Sets (writes to) the destination <see cref="JToken"/> from the source property value.
        /// </summary>
        /// <param name="value">The source value.</param>
        /// <param name="json">The <see cref="JToken"/>.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        public void SetDestValue(TSrce value, JToken json, OperationTypes operationType)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (json == null)
                throw new ArgumentNullException(nameof(json));

            var val = ((IODataPropertyMapper)this).GetDestValue(value, operationType);
            if (val == null)
                return;

            if (!IsSrceComplexType || Converter != null)
            {
                json[DestPropertyName] = new JValue(val);
                return;
            }

            var em = (IODataMapper)Mapper;
            switch (SrceComplexTypeReflector.ComplexTypeCode)
            {
                case Reflection.ComplexTypeCode.Object:
                    json[DestPropertyName] = em == null ? new JObject(val) : em.MapToOData(val, operationType);
                    break;

                default:
                    var jarray = new JArray();
                    foreach (var item in (System.Collections.IEnumerable)val)
                    {
                        jarray.Add(em == null ? new JValue(item) : em.MapToOData(item, operationType));
                    }

                    json[DestPropertyName] = jarray;
                    break;
            }
        }

        /// <summary>
        /// Gets the destination value from the <paramref name="value"/> and applies the <see cref="IPropertyMapperBase.Converter"/> where specified.
        /// </summary>
        /// <param name="value">The source value.</param>
        /// <param name="operationType">The single <see cref="Mapper.OperationTypes"/> being performed to enable selection.</param>
        /// <returns>The destination value equivalent.</returns>
        public object GetDestValue(object value, OperationTypes operationType)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var val = GetSrceValue((TSrce)value, operationType);
            if (Converter == null)
                return val;
            else
                return Converter.ConvertToDest(val);
        }
    }
}
