﻿// DigitalRune Engine - Copyright (C) DigitalRune GmbH
// This file is subject to the terms and conditions defined in
// file 'LICENSE.TXT', which is part of this source code package.

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace DigitalRune.Graphics.Content
{
  /// <summary>
  /// Reads a <see cref="MorphTarget"/> from binary format.
  /// </summary>
  public class MorphTargetReader : ContentTypeReader<MorphTarget>
  {
#if !MONOGAME
    /// <summary>
    /// Determines if deserialization into an existing object is possible.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the type can be deserialized into an existing instance; 
    /// <see langword="false"/> otherwise.
    /// </value>
    public override bool CanDeserializeIntoExistingObject
    {
      get { return true; }
    }
#endif


    /// <summary>
    /// Reads a strongly typed object from the current stream.
    /// </summary>
    /// <param name="input">The <see cref="ContentReader"/> used to read the object.</param>
    /// <param name="existingInstance">An existing object to read into.</param>
    /// <returns>The type of object to read.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods")]
    protected override MorphTarget Read(ContentReader input, MorphTarget existingInstance)
    {
      if (existingInstance == null)
        existingInstance = new MorphTarget();

      using (var helper = AssetLoadHelper.Get(input.AssetName))
      {
        existingInstance.Name = input.ReadString();
        input.ReadSharedResource(helper.Fixup<VertexBuffer>(vb => existingInstance.VertexBuffer = vb));
        existingInstance.StartVertex = input.ReadInt32();
      }

      return existingInstance;
    }
  }
}
