﻿// Decompiled with JetBrains decompiler
// Type: BananaLib.RiotObjects.Team.TeamId
// Assembly: BananaLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75213AF3-E339-4AEB-B3FE-095F85BC5F53
// Assembly location: C:\Users\Hesa\Desktop\eZ\BananaLib.dll

using RtmpSharp.IO;
using System;

namespace BananaLib.RiotObjects.Team
{
  [SerializedName("com.riotgames.team.TeamId")]
  [Serializable]
  public class TeamId
  {
    [SerializedName("fullId")]
    public string FullId { get; set; }
  }
}
