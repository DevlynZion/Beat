using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SomethingJustLikeThis 
{
    public static SongData Create()
    {
        var songLoader = Object.FindObjectOfType<SongLoaderController>();

        SongData song = new SongData();

        song.SongName = "Something Just Like This";

        Block1(song);
        Block2(song);
        Block3(song);
        Block2(song); // Block 4
        Block3(song); // Block 5
        Block2(song); // Block 6
        Block3(song); // Block 7
        Block8(song);
        Block8(song); // Block 9


        return song;
    }
    private static void Block1(SongData song)
    {
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 2
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 2
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 2
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 2
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 2
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 2
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 0
                }
            }
        });
    }
    private static void Block2(SongData song)
    {
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 1
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 1
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 1
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 1
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                }
            }
        });
    }
    private static void Block3(SongData song)
    {
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 4,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 4
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 4,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 4
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 4,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 4
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 4,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 11,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 3
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = 4
                }
            }
        });
    }
    private static void Block8(SongData song)
    {
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -4
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -4
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -4
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -4
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -4
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -4
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2f
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2f
                }
            }
        });
        song.Bars.Add(new BarData()
        {
            Beats = new List<BeatData>()
            {
                new BeatData()
                {
                    BeatNumber = 1,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 5,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 7,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 9,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -2
                },
                new BeatData()
                {
                    BeatNumber = 13,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                },
                new BeatData()
                {
                    BeatNumber = 15,
                    BeatPrephabName = "Beat",
                    HitAudioClipName = "",
                    YPosition = -3.5f
                }
            }
        });

    }
}
