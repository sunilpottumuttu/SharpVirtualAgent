﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UriExtensions.cs" company="Joan Caron">
// Copyright (c) 2014 All Rights Reserved
// </copyright>
// <author>Joan Caron</author>
// <summary>Implements the URI extensions class</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenWeatherMap
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Class UriExtensions.
    /// </summary>
    internal static class UriExtensions
    {
        /// <summary>
        ///     Adds the segment value to the url.
        /// </summary>
        /// <param name="originalUri">The original URI.</param>
        /// <param name="segment">    The segment .</param>
        /// <returns>
        ///     Uri .
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed. Suppression is OK here.")]
        public static Uri AddSegment(this Uri originalUri, string segment)
        {
            originalUri = new Uri(originalUri.OriginalString + "/" + segment);
            return originalUri;
        }

        /// <summary>
        ///     Adds the query value to the url.
        /// </summary>
        /// <param name="originalUri">The original URI.</param>
        /// <param name="segment">    The segment.</param>
        /// <returns>
        ///     Uri.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed. Suppression is OK here.")]
        public static Uri AddQuery(this Uri originalUri, string segment)
        {
            var uriBuilder = new UriBuilder(originalUri) { Query = segment };
            originalUri = uriBuilder.Uri;
            return originalUri;
        }
    }
}
