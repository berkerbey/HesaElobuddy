﻿// Decompiled with JetBrains decompiler
// Type: BananaLib.RiotObjects.Platform.SummonerDefaultSpells
// Assembly: BananaLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75213AF3-E339-4AEB-B3FE-095F85BC5F53
// Assembly location: C:\Users\Hesa\Desktop\eZ\BananaLib.dll

using RtmpSharp.IO;
using System;

namespace BananaLib.RiotObjects.Platform
{
  [SerializedName("com.riotgames.platform.summoner.SummonerDefaultSpells")]
  [Serializable]
  public class SummonerDefaultSpells
  {
    [SerializedName("summonerId")]
    public double SummonerId { get; set; }

    [SerializedName("summonerDefaultSpellsJson")]
    public object SummonerDefaultSpellsJson { get; set; }

    [SerializedName("summonerDefaultSpellMap")]
    public object SummonerDefaultSpellMap { get; set; }
  }
}
