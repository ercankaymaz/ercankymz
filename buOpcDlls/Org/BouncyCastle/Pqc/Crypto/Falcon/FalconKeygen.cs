// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconKeygen
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconKeygen
{
  private readonly FprEngine fpre;
  private readonly FalconFFT ffte;
  private readonly FalconSmallPrime[] PRIMES;
  private readonly FalconCodec codec;
  private readonly FalconVrfy vrfy;
  internal ushort[] REV10 = new ushort[1024 /*0x0400*/]
  {
    (ushort) 0,
    (ushort) 512 /*0x0200*/,
    (ushort) 256 /*0x0100*/,
    (ushort) 768 /*0x0300*/,
    (ushort) 128 /*0x80*/,
    (ushort) 640,
    (ushort) 384,
    (ushort) 896,
    (ushort) 64 /*0x40*/,
    (ushort) 576,
    (ushort) 320,
    (ushort) 832,
    (ushort) 192 /*0xC0*/,
    (ushort) 704,
    (ushort) 448,
    (ushort) 960,
    (ushort) 32 /*0x20*/,
    (ushort) 544,
    (ushort) 288,
    (ushort) 800,
    (ushort) 160 /*0xA0*/,
    (ushort) 672,
    (ushort) 416,
    (ushort) 928,
    (ushort) 96 /*0x60*/,
    (ushort) 608,
    (ushort) 352,
    (ushort) 864,
    (ushort) 224 /*0xE0*/,
    (ushort) 736,
    (ushort) 480,
    (ushort) 992,
    (ushort) 16 /*0x10*/,
    (ushort) 528,
    (ushort) 272,
    (ushort) 784,
    (ushort) 144 /*0x90*/,
    (ushort) 656,
    (ushort) 400,
    (ushort) 912,
    (ushort) 80 /*0x50*/,
    (ushort) 592,
    (ushort) 336,
    (ushort) 848,
    (ushort) 208 /*0xD0*/,
    (ushort) 720,
    (ushort) 464,
    (ushort) 976,
    (ushort) 48 /*0x30*/,
    (ushort) 560,
    (ushort) 304,
    (ushort) 816,
    (ushort) 176 /*0xB0*/,
    (ushort) 688,
    (ushort) 432,
    (ushort) 944,
    (ushort) 112 /*0x70*/,
    (ushort) 624,
    (ushort) 368,
    (ushort) 880,
    (ushort) 240 /*0xF0*/,
    (ushort) 752,
    (ushort) 496,
    (ushort) 1008,
    (ushort) 8,
    (ushort) 520,
    (ushort) 264,
    (ushort) 776,
    (ushort) 136,
    (ushort) 648,
    (ushort) 392,
    (ushort) 904,
    (ushort) 72,
    (ushort) 584,
    (ushort) 328,
    (ushort) 840,
    (ushort) 200,
    (ushort) 712,
    (ushort) 456,
    (ushort) 968,
    (ushort) 40,
    (ushort) 552,
    (ushort) 296,
    (ushort) 808,
    (ushort) 168,
    (ushort) 680,
    (ushort) 424,
    (ushort) 936,
    (ushort) 104,
    (ushort) 616,
    (ushort) 360,
    (ushort) 872,
    (ushort) 232,
    (ushort) 744,
    (ushort) 488,
    (ushort) 1000,
    (ushort) 24,
    (ushort) 536,
    (ushort) 280,
    (ushort) 792,
    (ushort) 152,
    (ushort) 664,
    (ushort) 408,
    (ushort) 920,
    (ushort) 88,
    (ushort) 600,
    (ushort) 344,
    (ushort) 856,
    (ushort) 216,
    (ushort) 728,
    (ushort) 472,
    (ushort) 984,
    (ushort) 56,
    (ushort) 568,
    (ushort) 312,
    (ushort) 824,
    (ushort) 184,
    (ushort) 696,
    (ushort) 440,
    (ushort) 952,
    (ushort) 120,
    (ushort) 632,
    (ushort) 376,
    (ushort) 888,
    (ushort) 248,
    (ushort) 760,
    (ushort) 504,
    (ushort) 1016,
    (ushort) 4,
    (ushort) 516,
    (ushort) 260,
    (ushort) 772,
    (ushort) 132,
    (ushort) 644,
    (ushort) 388,
    (ushort) 900,
    (ushort) 68,
    (ushort) 580,
    (ushort) 324,
    (ushort) 836,
    (ushort) 196,
    (ushort) 708,
    (ushort) 452,
    (ushort) 964,
    (ushort) 36,
    (ushort) 548,
    (ushort) 292,
    (ushort) 804,
    (ushort) 164,
    (ushort) 676,
    (ushort) 420,
    (ushort) 932,
    (ushort) 100,
    (ushort) 612,
    (ushort) 356,
    (ushort) 868,
    (ushort) 228,
    (ushort) 740,
    (ushort) 484,
    (ushort) 996,
    (ushort) 20,
    (ushort) 532,
    (ushort) 276,
    (ushort) 788,
    (ushort) 148,
    (ushort) 660,
    (ushort) 404,
    (ushort) 916,
    (ushort) 84,
    (ushort) 596,
    (ushort) 340,
    (ushort) 852,
    (ushort) 212,
    (ushort) 724,
    (ushort) 468,
    (ushort) 980,
    (ushort) 52,
    (ushort) 564,
    (ushort) 308,
    (ushort) 820,
    (ushort) 180,
    (ushort) 692,
    (ushort) 436,
    (ushort) 948,
    (ushort) 116,
    (ushort) 628,
    (ushort) 372,
    (ushort) 884,
    (ushort) 244,
    (ushort) 756,
    (ushort) 500,
    (ushort) 1012,
    (ushort) 12,
    (ushort) 524,
    (ushort) 268,
    (ushort) 780,
    (ushort) 140,
    (ushort) 652,
    (ushort) 396,
    (ushort) 908,
    (ushort) 76,
    (ushort) 588,
    (ushort) 332,
    (ushort) 844,
    (ushort) 204,
    (ushort) 716,
    (ushort) 460,
    (ushort) 972,
    (ushort) 44,
    (ushort) 556,
    (ushort) 300,
    (ushort) 812,
    (ushort) 172,
    (ushort) 684,
    (ushort) 428,
    (ushort) 940,
    (ushort) 108,
    (ushort) 620,
    (ushort) 364,
    (ushort) 876,
    (ushort) 236,
    (ushort) 748,
    (ushort) 492,
    (ushort) 1004,
    (ushort) 28,
    (ushort) 540,
    (ushort) 284,
    (ushort) 796,
    (ushort) 156,
    (ushort) 668,
    (ushort) 412,
    (ushort) 924,
    (ushort) 92,
    (ushort) 604,
    (ushort) 348,
    (ushort) 860,
    (ushort) 220,
    (ushort) 732,
    (ushort) 476,
    (ushort) 988,
    (ushort) 60,
    (ushort) 572,
    (ushort) 316,
    (ushort) 828,
    (ushort) 188,
    (ushort) 700,
    (ushort) 444,
    (ushort) 956,
    (ushort) 124,
    (ushort) 636,
    (ushort) 380,
    (ushort) 892,
    (ushort) 252,
    (ushort) 764,
    (ushort) 508,
    (ushort) 1020,
    (ushort) 2,
    (ushort) 514,
    (ushort) 258,
    (ushort) 770,
    (ushort) 130,
    (ushort) 642,
    (ushort) 386,
    (ushort) 898,
    (ushort) 66,
    (ushort) 578,
    (ushort) 322,
    (ushort) 834,
    (ushort) 194,
    (ushort) 706,
    (ushort) 450,
    (ushort) 962,
    (ushort) 34,
    (ushort) 546,
    (ushort) 290,
    (ushort) 802,
    (ushort) 162,
    (ushort) 674,
    (ushort) 418,
    (ushort) 930,
    (ushort) 98,
    (ushort) 610,
    (ushort) 354,
    (ushort) 866,
    (ushort) 226,
    (ushort) 738,
    (ushort) 482,
    (ushort) 994,
    (ushort) 18,
    (ushort) 530,
    (ushort) 274,
    (ushort) 786,
    (ushort) 146,
    (ushort) 658,
    (ushort) 402,
    (ushort) 914,
    (ushort) 82,
    (ushort) 594,
    (ushort) 338,
    (ushort) 850,
    (ushort) 210,
    (ushort) 722,
    (ushort) 466,
    (ushort) 978,
    (ushort) 50,
    (ushort) 562,
    (ushort) 306,
    (ushort) 818,
    (ushort) 178,
    (ushort) 690,
    (ushort) 434,
    (ushort) 946,
    (ushort) 114,
    (ushort) 626,
    (ushort) 370,
    (ushort) 882,
    (ushort) 242,
    (ushort) 754,
    (ushort) 498,
    (ushort) 1010,
    (ushort) 10,
    (ushort) 522,
    (ushort) 266,
    (ushort) 778,
    (ushort) 138,
    (ushort) 650,
    (ushort) 394,
    (ushort) 906,
    (ushort) 74,
    (ushort) 586,
    (ushort) 330,
    (ushort) 842,
    (ushort) 202,
    (ushort) 714,
    (ushort) 458,
    (ushort) 970,
    (ushort) 42,
    (ushort) 554,
    (ushort) 298,
    (ushort) 810,
    (ushort) 170,
    (ushort) 682,
    (ushort) 426,
    (ushort) 938,
    (ushort) 106,
    (ushort) 618,
    (ushort) 362,
    (ushort) 874,
    (ushort) 234,
    (ushort) 746,
    (ushort) 490,
    (ushort) 1002,
    (ushort) 26,
    (ushort) 538,
    (ushort) 282,
    (ushort) 794,
    (ushort) 154,
    (ushort) 666,
    (ushort) 410,
    (ushort) 922,
    (ushort) 90,
    (ushort) 602,
    (ushort) 346,
    (ushort) 858,
    (ushort) 218,
    (ushort) 730,
    (ushort) 474,
    (ushort) 986,
    (ushort) 58,
    (ushort) 570,
    (ushort) 314,
    (ushort) 826,
    (ushort) 186,
    (ushort) 698,
    (ushort) 442,
    (ushort) 954,
    (ushort) 122,
    (ushort) 634,
    (ushort) 378,
    (ushort) 890,
    (ushort) 250,
    (ushort) 762,
    (ushort) 506,
    (ushort) 1018,
    (ushort) 6,
    (ushort) 518,
    (ushort) 262,
    (ushort) 774,
    (ushort) 134,
    (ushort) 646,
    (ushort) 390,
    (ushort) 902,
    (ushort) 70,
    (ushort) 582,
    (ushort) 326,
    (ushort) 838,
    (ushort) 198,
    (ushort) 710,
    (ushort) 454,
    (ushort) 966,
    (ushort) 38,
    (ushort) 550,
    (ushort) 294,
    (ushort) 806,
    (ushort) 166,
    (ushort) 678,
    (ushort) 422,
    (ushort) 934,
    (ushort) 102,
    (ushort) 614,
    (ushort) 358,
    (ushort) 870,
    (ushort) 230,
    (ushort) 742,
    (ushort) 486,
    (ushort) 998,
    (ushort) 22,
    (ushort) 534,
    (ushort) 278,
    (ushort) 790,
    (ushort) 150,
    (ushort) 662,
    (ushort) 406,
    (ushort) 918,
    (ushort) 86,
    (ushort) 598,
    (ushort) 342,
    (ushort) 854,
    (ushort) 214,
    (ushort) 726,
    (ushort) 470,
    (ushort) 982,
    (ushort) 54,
    (ushort) 566,
    (ushort) 310,
    (ushort) 822,
    (ushort) 182,
    (ushort) 694,
    (ushort) 438,
    (ushort) 950,
    (ushort) 118,
    (ushort) 630,
    (ushort) 374,
    (ushort) 886,
    (ushort) 246,
    (ushort) 758,
    (ushort) 502,
    (ushort) 1014,
    (ushort) 14,
    (ushort) 526,
    (ushort) 270,
    (ushort) 782,
    (ushort) 142,
    (ushort) 654,
    (ushort) 398,
    (ushort) 910,
    (ushort) 78,
    (ushort) 590,
    (ushort) 334,
    (ushort) 846,
    (ushort) 206,
    (ushort) 718,
    (ushort) 462,
    (ushort) 974,
    (ushort) 46,
    (ushort) 558,
    (ushort) 302,
    (ushort) 814,
    (ushort) 174,
    (ushort) 686,
    (ushort) 430,
    (ushort) 942,
    (ushort) 110,
    (ushort) 622,
    (ushort) 366,
    (ushort) 878,
    (ushort) 238,
    (ushort) 750,
    (ushort) 494,
    (ushort) 1006,
    (ushort) 30,
    (ushort) 542,
    (ushort) 286,
    (ushort) 798,
    (ushort) 158,
    (ushort) 670,
    (ushort) 414,
    (ushort) 926,
    (ushort) 94,
    (ushort) 606,
    (ushort) 350,
    (ushort) 862,
    (ushort) 222,
    (ushort) 734,
    (ushort) 478,
    (ushort) 990,
    (ushort) 62,
    (ushort) 574,
    (ushort) 318,
    (ushort) 830,
    (ushort) 190,
    (ushort) 702,
    (ushort) 446,
    (ushort) 958,
    (ushort) 126,
    (ushort) 638,
    (ushort) 382,
    (ushort) 894,
    (ushort) 254,
    (ushort) 766,
    (ushort) 510,
    (ushort) 1022,
    (ushort) 1,
    (ushort) 513,
    (ushort) 257,
    (ushort) 769,
    (ushort) 129,
    (ushort) 641,
    (ushort) 385,
    (ushort) 897,
    (ushort) 65,
    (ushort) 577,
    (ushort) 321,
    (ushort) 833,
    (ushort) 193,
    (ushort) 705,
    (ushort) 449,
    (ushort) 961,
    (ushort) 33,
    (ushort) 545,
    (ushort) 289,
    (ushort) 801,
    (ushort) 161,
    (ushort) 673,
    (ushort) 417,
    (ushort) 929,
    (ushort) 97,
    (ushort) 609,
    (ushort) 353,
    (ushort) 865,
    (ushort) 225,
    (ushort) 737,
    (ushort) 481,
    (ushort) 993,
    (ushort) 17,
    (ushort) 529,
    (ushort) 273,
    (ushort) 785,
    (ushort) 145,
    (ushort) 657,
    (ushort) 401,
    (ushort) 913,
    (ushort) 81,
    (ushort) 593,
    (ushort) 337,
    (ushort) 849,
    (ushort) 209,
    (ushort) 721,
    (ushort) 465,
    (ushort) 977,
    (ushort) 49,
    (ushort) 561,
    (ushort) 305,
    (ushort) 817,
    (ushort) 177,
    (ushort) 689,
    (ushort) 433,
    (ushort) 945,
    (ushort) 113,
    (ushort) 625,
    (ushort) 369,
    (ushort) 881,
    (ushort) 241,
    (ushort) 753,
    (ushort) 497,
    (ushort) 1009,
    (ushort) 9,
    (ushort) 521,
    (ushort) 265,
    (ushort) 777,
    (ushort) 137,
    (ushort) 649,
    (ushort) 393,
    (ushort) 905,
    (ushort) 73,
    (ushort) 585,
    (ushort) 329,
    (ushort) 841,
    (ushort) 201,
    (ushort) 713,
    (ushort) 457,
    (ushort) 969,
    (ushort) 41,
    (ushort) 553,
    (ushort) 297,
    (ushort) 809,
    (ushort) 169,
    (ushort) 681,
    (ushort) 425,
    (ushort) 937,
    (ushort) 105,
    (ushort) 617,
    (ushort) 361,
    (ushort) 873,
    (ushort) 233,
    (ushort) 745,
    (ushort) 489,
    (ushort) 1001,
    (ushort) 25,
    (ushort) 537,
    (ushort) 281,
    (ushort) 793,
    (ushort) 153,
    (ushort) 665,
    (ushort) 409,
    (ushort) 921,
    (ushort) 89,
    (ushort) 601,
    (ushort) 345,
    (ushort) 857,
    (ushort) 217,
    (ushort) 729,
    (ushort) 473,
    (ushort) 985,
    (ushort) 57,
    (ushort) 569,
    (ushort) 313,
    (ushort) 825,
    (ushort) 185,
    (ushort) 697,
    (ushort) 441,
    (ushort) 953,
    (ushort) 121,
    (ushort) 633,
    (ushort) 377,
    (ushort) 889,
    (ushort) 249,
    (ushort) 761,
    (ushort) 505,
    (ushort) 1017,
    (ushort) 5,
    (ushort) 517,
    (ushort) 261,
    (ushort) 773,
    (ushort) 133,
    (ushort) 645,
    (ushort) 389,
    (ushort) 901,
    (ushort) 69,
    (ushort) 581,
    (ushort) 325,
    (ushort) 837,
    (ushort) 197,
    (ushort) 709,
    (ushort) 453,
    (ushort) 965,
    (ushort) 37,
    (ushort) 549,
    (ushort) 293,
    (ushort) 805,
    (ushort) 165,
    (ushort) 677,
    (ushort) 421,
    (ushort) 933,
    (ushort) 101,
    (ushort) 613,
    (ushort) 357,
    (ushort) 869,
    (ushort) 229,
    (ushort) 741,
    (ushort) 485,
    (ushort) 997,
    (ushort) 21,
    (ushort) 533,
    (ushort) 277,
    (ushort) 789,
    (ushort) 149,
    (ushort) 661,
    (ushort) 405,
    (ushort) 917,
    (ushort) 85,
    (ushort) 597,
    (ushort) 341,
    (ushort) 853,
    (ushort) 213,
    (ushort) 725,
    (ushort) 469,
    (ushort) 981,
    (ushort) 53,
    (ushort) 565,
    (ushort) 309,
    (ushort) 821,
    (ushort) 181,
    (ushort) 693,
    (ushort) 437,
    (ushort) 949,
    (ushort) 117,
    (ushort) 629,
    (ushort) 373,
    (ushort) 885,
    (ushort) 245,
    (ushort) 757,
    (ushort) 501,
    (ushort) 1013,
    (ushort) 13,
    (ushort) 525,
    (ushort) 269,
    (ushort) 781,
    (ushort) 141,
    (ushort) 653,
    (ushort) 397,
    (ushort) 909,
    (ushort) 77,
    (ushort) 589,
    (ushort) 333,
    (ushort) 845,
    (ushort) 205,
    (ushort) 717,
    (ushort) 461,
    (ushort) 973,
    (ushort) 45,
    (ushort) 557,
    (ushort) 301,
    (ushort) 813,
    (ushort) 173,
    (ushort) 685,
    (ushort) 429,
    (ushort) 941,
    (ushort) 109,
    (ushort) 621,
    (ushort) 365,
    (ushort) 877,
    (ushort) 237,
    (ushort) 749,
    (ushort) 493,
    (ushort) 1005,
    (ushort) 29,
    (ushort) 541,
    (ushort) 285,
    (ushort) 797,
    (ushort) 157,
    (ushort) 669,
    (ushort) 413,
    (ushort) 925,
    (ushort) 93,
    (ushort) 605,
    (ushort) 349,
    (ushort) 861,
    (ushort) 221,
    (ushort) 733,
    (ushort) 477,
    (ushort) 989,
    (ushort) 61,
    (ushort) 573,
    (ushort) 317,
    (ushort) 829,
    (ushort) 189,
    (ushort) 701,
    (ushort) 445,
    (ushort) 957,
    (ushort) 125,
    (ushort) 637,
    (ushort) 381,
    (ushort) 893,
    (ushort) 253,
    (ushort) 765,
    (ushort) 509,
    (ushort) 1021,
    (ushort) 3,
    (ushort) 515,
    (ushort) 259,
    (ushort) 771,
    (ushort) 131,
    (ushort) 643,
    (ushort) 387,
    (ushort) 899,
    (ushort) 67,
    (ushort) 579,
    (ushort) 323,
    (ushort) 835,
    (ushort) 195,
    (ushort) 707,
    (ushort) 451,
    (ushort) 963,
    (ushort) 35,
    (ushort) 547,
    (ushort) 291,
    (ushort) 803,
    (ushort) 163,
    (ushort) 675,
    (ushort) 419,
    (ushort) 931,
    (ushort) 99,
    (ushort) 611,
    (ushort) 355,
    (ushort) 867,
    (ushort) 227,
    (ushort) 739,
    (ushort) 483,
    (ushort) 995,
    (ushort) 19,
    (ushort) 531,
    (ushort) 275,
    (ushort) 787,
    (ushort) 147,
    (ushort) 659,
    (ushort) 403,
    (ushort) 915,
    (ushort) 83,
    (ushort) 595,
    (ushort) 339,
    (ushort) 851,
    (ushort) 211,
    (ushort) 723,
    (ushort) 467,
    (ushort) 979,
    (ushort) 51,
    (ushort) 563,
    (ushort) 307,
    (ushort) 819,
    (ushort) 179,
    (ushort) 691,
    (ushort) 435,
    (ushort) 947,
    (ushort) 115,
    (ushort) 627,
    (ushort) 371,
    (ushort) 883,
    (ushort) 243,
    (ushort) 755,
    (ushort) 499,
    (ushort) 1011,
    (ushort) 11,
    (ushort) 523,
    (ushort) 267,
    (ushort) 779,
    (ushort) 139,
    (ushort) 651,
    (ushort) 395,
    (ushort) 907,
    (ushort) 75,
    (ushort) 587,
    (ushort) 331,
    (ushort) 843,
    (ushort) 203,
    (ushort) 715,
    (ushort) 459,
    (ushort) 971,
    (ushort) 43,
    (ushort) 555,
    (ushort) 299,
    (ushort) 811,
    (ushort) 171,
    (ushort) 683,
    (ushort) 427,
    (ushort) 939,
    (ushort) 107,
    (ushort) 619,
    (ushort) 363,
    (ushort) 875,
    (ushort) 235,
    (ushort) 747,
    (ushort) 491,
    (ushort) 1003,
    (ushort) 27,
    (ushort) 539,
    (ushort) 283,
    (ushort) 795,
    (ushort) 155,
    (ushort) 667,
    (ushort) 411,
    (ushort) 923,
    (ushort) 91,
    (ushort) 603,
    (ushort) 347,
    (ushort) 859,
    (ushort) 219,
    (ushort) 731,
    (ushort) 475,
    (ushort) 987,
    (ushort) 59,
    (ushort) 571,
    (ushort) 315,
    (ushort) 827,
    (ushort) 187,
    (ushort) 699,
    (ushort) 443,
    (ushort) 955,
    (ushort) 123,
    (ushort) 635,
    (ushort) 379,
    (ushort) 891,
    (ushort) 251,
    (ushort) 763,
    (ushort) 507,
    (ushort) 1019,
    (ushort) 7,
    (ushort) 519,
    (ushort) 263,
    (ushort) 775,
    (ushort) 135,
    (ushort) 647,
    (ushort) 391,
    (ushort) 903,
    (ushort) 71,
    (ushort) 583,
    (ushort) 327,
    (ushort) 839,
    (ushort) 199,
    (ushort) 711,
    (ushort) 455,
    (ushort) 967,
    (ushort) 39,
    (ushort) 551,
    (ushort) 295,
    (ushort) 807,
    (ushort) 167,
    (ushort) 679,
    (ushort) 423,
    (ushort) 935,
    (ushort) 103,
    (ushort) 615,
    (ushort) 359,
    (ushort) 871,
    (ushort) 231,
    (ushort) 743,
    (ushort) 487,
    (ushort) 999,
    (ushort) 23,
    (ushort) 535,
    (ushort) 279,
    (ushort) 791,
    (ushort) 151,
    (ushort) 663,
    (ushort) 407,
    (ushort) 919,
    (ushort) 87,
    (ushort) 599,
    (ushort) 343,
    (ushort) 855,
    (ushort) 215,
    (ushort) 727,
    (ushort) 471,
    (ushort) 983,
    (ushort) 55,
    (ushort) 567,
    (ushort) 311,
    (ushort) 823,
    (ushort) 183,
    (ushort) 695,
    (ushort) 439,
    (ushort) 951,
    (ushort) 119,
    (ushort) 631,
    (ushort) 375,
    (ushort) 887,
    (ushort) 247,
    (ushort) 759,
    (ushort) 503,
    (ushort) 1015,
    (ushort) 15,
    (ushort) 527,
    (ushort) 271,
    (ushort) 783,
    (ushort) 143,
    (ushort) 655,
    (ushort) 399,
    (ushort) 911,
    (ushort) 79,
    (ushort) 591,
    (ushort) 335,
    (ushort) 847,
    (ushort) 207,
    (ushort) 719,
    (ushort) 463,
    (ushort) 975,
    (ushort) 47,
    (ushort) 559,
    (ushort) 303,
    (ushort) 815,
    (ushort) 175,
    (ushort) 687,
    (ushort) 431,
    (ushort) 943,
    (ushort) 111,
    (ushort) 623,
    (ushort) 367,
    (ushort) 879,
    (ushort) 239,
    (ushort) 751,
    (ushort) 495,
    (ushort) 1007,
    (ushort) 31 /*0x1F*/,
    (ushort) 543,
    (ushort) 287,
    (ushort) 799,
    (ushort) 159,
    (ushort) 671,
    (ushort) 415,
    (ushort) 927,
    (ushort) 95,
    (ushort) 607,
    (ushort) 351,
    (ushort) 863,
    (ushort) 223,
    (ushort) 735,
    (ushort) 479,
    (ushort) 991,
    (ushort) 63 /*0x3F*/,
    (ushort) 575,
    (ushort) 319,
    (ushort) 831,
    (ushort) 191,
    (ushort) 703,
    (ushort) 447,
    (ushort) 959,
    (ushort) sbyte.MaxValue,
    (ushort) 639,
    (ushort) 383,
    (ushort) 895,
    (ushort) byte.MaxValue,
    (ushort) 767 /*0x02FF*/,
    (ushort) 511 /*0x01FF*/,
    (ushort) 1023 /*0x03FF*/
  };
  internal ulong[] gauss_1024_12289 = new ulong[27]
  {
    1283868770400643928UL,
    6416574995475331444UL,
    4078260278032692663UL,
    2353523259288686585UL,
    1227179971273316331UL,
    575931623374121527UL,
    242543240509105209UL,
    91437049221049666UL,
    30799446349977173UL,
    9255276791179340UL,
    2478152334826140UL,
    590642893610164UL,
    125206034929641UL,
    23590435911403UL,
    3948334035941UL,
    586753615614UL,
    77391054539UL,
    9056793210UL,
    940121950UL,
    86539696UL,
    7062824UL,
    510971UL,
    32764UL,
    1862UL,
    94UL,
    4UL,
    0UL
  };
  internal int[] MAX_BL_SMALL = new int[11]
  {
    1,
    1,
    2,
    2,
    4,
    7,
    14,
    27,
    53,
    106,
    209
  };
  internal int[] MAX_BL_LARGE = new int[10]
  {
    2,
    2,
    5,
    7,
    12,
    21,
    40,
    78,
    157,
    308
  };
  internal int[] BITLENGTH_avg = new int[11]
  {
    4,
    11,
    24,
    50,
    102,
    202,
    401,
    794,
    1577,
    3138,
    6308
  };
  internal int[] BITLENGTH_std = new int[11]
  {
    0,
    1,
    1,
    1,
    1,
    2,
    4,
    5,
    8,
    13,
    25
  };
  internal const int DEPTH_INT_FG = 4;

  internal FalconKeygen()
  {
    this.fpre = new FprEngine();
    this.PRIMES = new FalconSmallPrimes().PRIMES;
    this.ffte = new FalconFFT(this.fpre);
    this.codec = new FalconCodec();
    this.vrfy = new FalconVrfy();
  }

  internal FalconKeygen(FalconCodec codec, FalconVrfy vrfy)
  {
    this.fpre = new FprEngine();
    this.PRIMES = new FalconSmallPrimes().PRIMES;
    this.ffte = new FalconFFT();
    this.codec = codec;
    this.vrfy = vrfy;
  }

  internal uint modp_set(int x, uint p)
  {
    uint num = (uint) x;
    return num + (uint) ((ulong) p & (ulong) -(num >> 31 /*0x1F*/));
  }

  internal int modp_norm(uint x, uint p)
  {
    return (int) x - ((int) p & (int) (x - (p + 1U >> 1) >> 31 /*0x1F*/) - 1);
  }

  internal uint modp_ninv31(uint p)
  {
    uint num1 = 2U - p;
    uint num2 = num1 * (uint) (2 - (int) p * (int) num1);
    uint num3 = num2 * (uint) (2 - (int) p * (int) num2);
    uint num4 = num3 * (uint) (2 - (int) p * (int) num3);
    return (uint) ((ulong) int.MaxValue & (ulong) -(num4 * (uint) (2 - (int) p * (int) num4)));
  }

  internal uint modp_R(uint p) => 2147483648U /*0x80000000*/ - p;

  internal uint modp_add(uint a, uint b, uint p)
  {
    uint num = a + b - p;
    return num + (uint) ((ulong) p & (ulong) -(num >> 31 /*0x1F*/));
  }

  internal uint modp_sub(uint a, uint b, uint p)
  {
    uint num = a - b;
    return num + (uint) ((ulong) p & (ulong) -(num >> 31 /*0x1F*/));
  }

  internal uint modp_montymul(uint a, uint b, uint p, uint p0i)
  {
    long num1 = (long) a * (long) b;
    uint num2 = (uint) ((ulong) num1 + (ulong) (num1 * (long) p0i & (long) int.MaxValue) * (ulong) p >> 31 /*0x1F*/) - p;
    return num2 + (uint) ((ulong) p & (ulong) -(num2 >> 31 /*0x1F*/));
  }

  internal uint modp_R2(uint p, uint p0i)
  {
    uint num1 = this.modp_R(p);
    uint num2 = this.modp_add(num1, num1, p);
    uint num3 = this.modp_montymul(num2, num2, p, p0i);
    uint num4 = this.modp_montymul(num3, num3, p, p0i);
    uint num5 = this.modp_montymul(num4, num4, p, p0i);
    uint num6 = this.modp_montymul(num5, num5, p, p0i);
    uint num7 = this.modp_montymul(num6, num6, p, p0i);
    return (uint) ((long) num7 + ((long) p & (long) -(num7 & 1U)) >> 1);
  }

  internal uint modp_Rx(uint x, uint p, uint p0i, uint R2)
  {
    --x;
    uint num = R2;
    uint a = this.modp_R(p);
    for (int index = 0; (uint) (1 << index) <= x; ++index)
    {
      if (((int) x & 1 << index) != 0)
        a = this.modp_montymul(a, num, p, p0i);
      num = this.modp_montymul(num, num, p, p0i);
    }
    return a;
  }

  internal uint modp_div(uint a, uint b, uint p, uint p0i, uint R)
  {
    uint num1 = p - 2U;
    uint num2 = R;
    for (int index = 30; index >= 0; --index)
    {
      uint a1 = this.modp_montymul(num2, num2, p, p0i);
      uint num3 = this.modp_montymul(a1, b, p, p0i);
      num2 = a1 ^ (uint) ((ulong) (a1 ^ num3) & (ulong) -(num1 >> index & 1U));
    }
    uint b1 = this.modp_montymul(num2, 1U, p, p0i);
    return this.modp_montymul(a, b1, p, p0i);
  }

  internal void modp_mkgm2(
    uint[] gmsrc,
    int gm,
    uint[] igmsrc,
    int igm,
    uint logn,
    uint g,
    uint p,
    uint p0i)
  {
    int num1 = 1 << (int) logn;
    uint num2 = this.modp_R2(p, p0i);
    g = this.modp_montymul(g, num2, p, p0i);
    for (uint index = logn; index < 10U; ++index)
      g = this.modp_montymul(g, g, p, p0i);
    uint b = this.modp_div(num2, g, p, p0i, this.modp_R(p));
    uint num3 = 10U - logn;
    uint a1;
    uint a2 = a1 = this.modp_R(p);
    for (int index = 0; index < num1; ++index)
    {
      int num4 = (int) this.REV10[index << (int) num3];
      gmsrc[gm + num4] = a2;
      igmsrc[igm + num4] = a1;
      a2 = this.modp_montymul(a2, g, p, p0i);
      a1 = this.modp_montymul(a1, b, p, p0i);
    }
  }

  internal void modp_NTT2_ext(
    uint[] asrc,
    int a,
    int stride,
    uint[] gmsrc,
    int gm,
    uint logn,
    uint p,
    uint p0i)
  {
    if (logn == 0U)
      return;
    int num1 = 1 << (int) logn;
    int num2 = num1;
    for (int index1 = 1; index1 < num1; index1 <<= 1)
    {
      int num3 = num2 >> 1;
      int num4 = 0;
      int num5 = 0;
      while (num4 < index1)
      {
        uint b1 = gmsrc[gm + index1 + num4];
        int index2 = a + num5 * stride;
        int index3 = index2 + num3 * stride;
        int num6 = 0;
        while (num6 < num3)
        {
          uint a1 = asrc[index2];
          uint b2 = this.modp_montymul(asrc[index3], b1, p, p0i);
          asrc[index2] = this.modp_add(a1, b2, p);
          asrc[index3] = this.modp_sub(a1, b2, p);
          ++num6;
          index2 += stride;
          index3 += stride;
        }
        ++num4;
        num5 += num2;
      }
      num2 = num3;
    }
  }

  internal void modp_iNTT2_ext(
    uint[] asrc,
    int a,
    int stride,
    uint[] igmsrc,
    int igm,
    uint logn,
    uint p,
    uint p0i)
  {
    if (logn == 0U)
      return;
    int num1 = 1 << (int) logn;
    int num2 = 1;
    for (int index1 = num1; index1 > 1; index1 >>= 1)
    {
      int num3 = index1 >> 1;
      int num4 = num2 << 1;
      int num5 = 0;
      int num6 = 0;
      while (num5 < num3)
      {
        uint b1 = igmsrc[igm + num3 + num5];
        int index2 = a + num6 * stride;
        int index3 = index2 + num2 * stride;
        int num7 = 0;
        while (num7 < num2)
        {
          uint a1 = asrc[index2];
          uint b2 = asrc[index3];
          asrc[index2] = this.modp_add(a1, b2, p);
          asrc[index3] = this.modp_montymul(this.modp_sub(a1, b2, p), b1, p, p0i);
          ++num7;
          index2 += stride;
          index3 += stride;
        }
        ++num5;
        num6 += num4;
      }
      num2 = num4;
    }
    uint b = (uint) (1 << 31 /*0x1F*/ - (int) logn);
    int num8 = 0;
    int index = a;
    while (num8 < num1)
    {
      asrc[index] = this.modp_montymul(asrc[index], b, p, p0i);
      ++num8;
      index += stride;
    }
  }

  internal void modp_NTT2(
    uint[] asrc,
    int a,
    uint[] gmsrc,
    int gm,
    uint logn,
    uint p,
    uint p0i)
  {
    this.modp_NTT2_ext(asrc, a, 1, gmsrc, gm, logn, p, p0i);
  }

  internal void modp_iNTT2(
    uint[] asrc,
    int a,
    uint[] igmsrc,
    int igm,
    uint logn,
    uint p,
    uint p0i)
  {
    this.modp_iNTT2_ext(asrc, a, 1, igmsrc, igm, logn, p, p0i);
  }

  internal void modp_poly_rec_res(uint[] fsrc, int f, uint logn, uint p, uint p0i, uint R2)
  {
    int num = 1 << (int) logn - 1;
    for (int index = 0; index < num; ++index)
    {
      uint a = fsrc[f + (index << 1)];
      uint b = fsrc[f + (index << 1) + 1];
      fsrc[f + index] = this.modp_montymul(this.modp_montymul(a, b, p, p0i), R2, p, p0i);
    }
  }

  internal uint zint_sub(uint[] asrc, int a, uint[] bsrc, int b, int len, uint ctl)
  {
    uint num1 = 0;
    uint num2 = -ctl;
    for (int index = 0; index < len; ++index)
    {
      uint num3 = asrc[a + index];
      uint num4 = num3 - bsrc[b + index] - num1;
      num1 = num4 >> 31 /*0x1F*/;
      uint num5 = num3 ^ (num4 & (uint) int.MaxValue ^ num3) & num2;
      asrc[a + index] = num5;
    }
    return num1;
  }

  internal uint zint_mul_small(uint[] msrc, int m, int mlen, uint x)
  {
    uint num1 = 0;
    for (int index = 0; index < mlen; ++index)
    {
      ulong num2 = (ulong) msrc[m + index] * (ulong) x + (ulong) num1;
      msrc[m + index] = (uint) num2 & (uint) int.MaxValue;
      num1 = (uint) (num2 >> 31 /*0x1F*/);
    }
    return num1;
  }

  internal uint zint_mod_small_uint(uint[] dsrc, int d, int dlen, uint p, uint p0i, uint R2)
  {
    uint a1 = 0;
    int num1 = dlen;
    while (num1-- > 0)
    {
      uint a2 = this.modp_montymul(a1, R2, p, p0i);
      uint num2 = dsrc[d + num1] - p;
      uint b = num2 + (uint) ((ulong) p & (ulong) -(num2 >> 31 /*0x1F*/));
      a1 = this.modp_add(a2, b, p);
    }
    return a1;
  }

  internal uint zint_mod_small_signed(
    uint[] dsrc,
    int d,
    int dlen,
    uint p,
    uint p0i,
    uint R2,
    uint Rx)
  {
    return dlen == 0 ? 0U : this.modp_sub(this.zint_mod_small_uint(dsrc, d, dlen, p, p0i, R2), (uint) ((ulong) Rx & (ulong) -(dsrc[d + dlen - 1] >> 30)), p);
  }

  internal void zint_add_mul_small(uint[] xsrc, int x, uint[] ysrc, int y, int len, uint s)
  {
    uint num1 = 0;
    for (int index = 0; index < len; ++index)
    {
      uint num2 = xsrc[x + index];
      ulong num3 = (ulong) ysrc[y + index] * (ulong) s + (ulong) num2 + (ulong) num1;
      xsrc[x + index] = (uint) num3 & (uint) int.MaxValue;
      num1 = (uint) (num3 >> 31 /*0x1F*/);
    }
    xsrc[x + len] = num1;
  }

  internal void zint_norm_zero(uint[] xsrc, int x, uint[] psrc, int p, int len)
  {
    uint num1 = 0;
    uint num2 = 0;
    int num3 = len;
    while (num3-- > 0)
    {
      uint num4 = xsrc[x + num3];
      int num5 = (int) (psrc[p + num3] >> 1) | (int) num2 << 30;
      num2 = psrc[p + num3] & 1U;
      int num6 = (int) num4;
      uint num7 = (uint) (num5 - num6);
      uint num8 = -num7 >> 31 /*0x1F*/ | -(num7 >> 31 /*0x1F*/);
      num1 |= num8 & (uint) (((int) num1 & 1) - 1);
    }
    int num9 = (int) this.zint_sub(xsrc, x, psrc, p, len, num1 >> 31 /*0x1F*/);
  }

  internal void zint_rebuild_CRT(
    uint[] xxsrc,
    int xx,
    int xlen,
    int xstride,
    int num,
    FalconSmallPrime[] primes,
    int normalize_signed,
    uint[] tmpsrc,
    int tmp)
  {
    tmpsrc[tmp] = primes[0].p;
    for (int index = 1; index < xlen; ++index)
    {
      uint p = primes[index].p;
      uint s1 = primes[index].s;
      uint p0i = this.modp_ninv31(p);
      uint R2 = this.modp_R2(p, p0i);
      int num1 = 0;
      int num2 = xx;
      while (num1 < num)
      {
        uint a = xxsrc[num2 + index];
        uint b = this.zint_mod_small_uint(xxsrc, num2, index, p, p0i, R2);
        uint s2 = this.modp_montymul(s1, this.modp_sub(a, b, p), p, p0i);
        this.zint_add_mul_small(xxsrc, num2, tmpsrc, tmp, index, s2);
        ++num1;
        num2 += xstride;
      }
      tmpsrc[tmp + index] = this.zint_mul_small(tmpsrc, tmp, index, p);
    }
    if (normalize_signed == 0)
      return;
    int num3 = 0;
    int x = xx;
    while (num3 < num)
    {
      this.zint_norm_zero(xxsrc, x, tmpsrc, tmp, xlen);
      ++num3;
      x += xstride;
    }
  }

  internal void zint_negate(uint[] asrc, int a, int len, uint ctl)
  {
    uint num1 = ctl;
    uint num2 = -ctl >> 1;
    for (int index = 0; index < len; ++index)
    {
      uint num3 = (asrc[a + index] ^ num2) + num1;
      asrc[a + index] = num3 & (uint) int.MaxValue;
      num1 = num3 >> 31 /*0x1F*/;
    }
  }

  internal uint zint_co_reduce(
    uint[] asrc,
    int a,
    uint[] bsrc,
    int b,
    int len,
    long xa,
    long xb,
    long ya,
    long yb)
  {
    long num1 = 0;
    long num2 = 0;
    for (int index = 0; index < len; ++index)
    {
      int num3 = (int) asrc[a + index];
      uint num4 = bsrc[b + index];
      ulong num5 = (ulong) ((long) (uint) num3 * xa + (long) num4 * xb + num1);
      ulong num6 = (ulong) ((long) (uint) num3 * ya + (long) num4 * yb + num2);
      if (index > 0)
      {
        asrc[a + index - 1] = (uint) num5 & (uint) int.MaxValue;
        bsrc[b + index - 1] = (uint) num6 & (uint) int.MaxValue;
      }
      num1 = (long) num5 >> 31 /*0x1F*/;
      num2 = (long) num6 >> 31 /*0x1F*/;
    }
    asrc[a + len - 1] = (uint) num1;
    bsrc[b + len - 1] = (uint) num2;
    uint ctl1 = (uint) (num1 >>> 63 /*0x3F*/);
    uint ctl2 = (uint) (num2 >>> 63 /*0x3F*/);
    this.zint_negate(asrc, a, len, ctl1);
    this.zint_negate(bsrc, b, len, ctl2);
    return ctl1 | ctl2 << 1;
  }

  internal void zint_finish_mod(uint[] asrc, int a, int len, uint[] msrc, int m, uint neg)
  {
    uint num1 = 0;
    for (int index = 0; index < len; ++index)
      num1 = asrc[a + index] - msrc[m + index] - num1 >> 31 /*0x1F*/;
    uint num2 = -neg >> 1;
    uint num3 = -(neg | 1U - num1);
    uint num4 = neg;
    for (int index = 0; index < len; ++index)
    {
      uint num5 = asrc[a + index] - ((msrc[m + index] ^ num2) & num3) - num4;
      asrc[a + index] = num5 & (uint) int.MaxValue;
      num4 = num5 >> 31 /*0x1F*/;
    }
  }

  internal void zint_co_reduce_mod(
    uint[] asrc,
    int a,
    uint[] bsrc,
    int b,
    uint[] msrc,
    int m,
    int len,
    uint m0i,
    long xa,
    long xb,
    long ya,
    long yb)
  {
    long num1 = 0;
    long num2 = 0;
    uint num3 = (uint) (((int) asrc[a] * (int) (uint) xa + (int) bsrc[b] * (int) (uint) xb) * (int) m0i & int.MaxValue);
    uint num4 = (uint) (((int) asrc[a] * (int) (uint) ya + (int) bsrc[b] * (int) (uint) yb) * (int) m0i & int.MaxValue);
    for (int index = 0; index < len; ++index)
    {
      int num5 = (int) asrc[a + index];
      uint num6 = bsrc[b + index];
      ulong num7 = (ulong) ((long) (uint) num5 * xa + (long) num6 * xb + (long) msrc[m + index] * (long) num3 + num1);
      ulong num8 = (ulong) ((long) (uint) num5 * ya + (long) num6 * yb + (long) msrc[m + index] * (long) num4 + num2);
      if (index > 0)
      {
        asrc[a + index - 1] = (uint) num7 & (uint) int.MaxValue;
        bsrc[b + index - 1] = (uint) num8 & (uint) int.MaxValue;
      }
      num1 = (long) num7 >> 31 /*0x1F*/;
      num2 = (long) num8 >> 31 /*0x1F*/;
    }
    asrc[a + len - 1] = (uint) num1;
    bsrc[b + len - 1] = (uint) num2;
    this.zint_finish_mod(asrc, a, len, msrc, m, (uint) (num1 >>> 63 /*0x3F*/));
    this.zint_finish_mod(bsrc, b, len, msrc, m, (uint) (num2 >>> 63 /*0x3F*/));
  }

  internal int zint_bezout(
    uint[] usrc,
    int u,
    uint[] vsrc,
    int v,
    uint[] xsrc,
    int x,
    uint[] ysrc,
    int y,
    int len,
    uint[] tmpsrc,
    int tmp)
  {
    if (len == 0)
      return 0;
    int a1 = u;
    int a2 = v;
    int num1 = tmp;
    int index1 = num1 + len;
    int index2 = index1 + len;
    int index3 = index2 + len;
    uint m0i1 = this.modp_ninv31(xsrc[x]);
    uint m0i2 = this.modp_ninv31(ysrc[y]);
    Array.Copy((Array) xsrc, x, (Array) tmpsrc, index2, len);
    Array.Copy((Array) ysrc, y, (Array) tmpsrc, index3, len);
    usrc[a1] = 1U;
    for (int index4 = 1; index4 < len; ++index4)
    {
      usrc[a1 + index4] = 0U;
      vsrc[a2 + index4] = 0U;
    }
    vsrc[a2] = 0U;
    Array.Copy((Array) ysrc, y, (Array) tmpsrc, num1, len);
    Array.Copy((Array) xsrc, x, (Array) tmpsrc, index1, len);
    --tmpsrc[index1];
    for (uint index5 = (uint) (62 * len + 30); index5 >= 30U; index5 -= 30U)
    {
      uint maxValue = uint.MaxValue;
      uint num2 = uint.MaxValue;
      uint num3 = 0;
      uint num4 = 0;
      uint num5 = 0;
      uint num6 = 0;
      int num7 = len;
      while (num7-- > 0)
      {
        uint num8 = tmpsrc[index2 + num7];
        uint num9 = tmpsrc[index3 + num7];
        num3 ^= (num3 ^ num8) & maxValue;
        num4 ^= (num4 ^ num8) & num2;
        num5 ^= (num5 ^ num9) & maxValue;
        num6 ^= (num6 ^ num9) & num2;
        num2 = maxValue;
        maxValue &= (uint) ((((int) num8 | (int) num9) + int.MaxValue >>> 31 /*0x1F*/) - 1);
      }
      uint num10 = num4 | num3 & num2;
      uint num11 = num3 & ~num2;
      uint num12 = num6 | num5 & num2;
      uint num13 = num5 & ~num2;
      ulong num14 = ((ulong) num11 << 31 /*0x1F*/) + (ulong) num10;
      ulong num15 = ((ulong) num13 << 31 /*0x1F*/) + (ulong) num12;
      uint num16 = tmpsrc[index2];
      uint num17 = tmpsrc[index3];
      long xa1 = 1;
      long xb1 = 0;
      long ya1 = 0;
      long yb1 = 1;
      for (int index6 = 0; index6 < 31 /*0x1F*/; ++index6)
      {
        ulong num18 = num15 - num14;
        uint num19 = (uint) ((num18 ^ (ulong) (((long) num14 ^ (long) num15) & ((long) num14 ^ (long) num18))) >> 63 /*0x3F*/);
        uint num20 = num16 >> index6 & 1U;
        uint num21 = num17 >> index6 & 1U;
        uint num22 = num20 & num21 & num19;
        uint num23 = (uint) ((ulong) (num20 & num21) & (ulong) ~(int) num19);
        uint num24 = num22 | num20 ^ 1U;
        uint num25 = num16 - (uint) ((ulong) num17 & (ulong) -num22);
        ulong num26 = num14 - (num15 & (ulong) -num22);
        long num27 = xa1 - (ya1 & (long) -num22);
        long num28 = xb1 - (yb1 & (long) -num22);
        uint num29 = num17 - (uint) ((ulong) num25 & (ulong) -num23);
        ulong num30 = num15 - (num26 & (ulong) -num23);
        long num31 = ya1 - (num27 & (long) -num23);
        long num32 = yb1 - (num28 & (long) -num23);
        num16 = num25 + (num25 & num24 - 1U);
        xa1 = num27 + (num27 & (long) num24 - 1L);
        xb1 = num28 + (num28 & (long) num24 - 1L);
        num14 = num26 ^ (num26 ^ num26 >> 1) & (ulong) -num24;
        num17 = num29 + (uint) ((ulong) num29 & (ulong) -num24);
        ya1 = num31 + (num31 & (long) -num24);
        yb1 = num32 + (num32 & (long) -num24);
        num15 = num30 ^ (ulong) (((long) num30 ^ (long) (num30 >> 1)) & (long) num24 - 1L);
      }
      uint num33 = this.zint_co_reduce(tmpsrc, index2, tmpsrc, index3, len, xa1, xb1, ya1, yb1);
      long xa2 = xa1 - (xa1 + xa1 & (long) -(num33 & 1U));
      long xb2 = xb1 - (xb1 + xb1 & (long) -(num33 & 1U));
      long ya2 = ya1 - (ya1 + ya1 & (long) -(num33 >> 1));
      long yb2 = yb1 - (yb1 + yb1 & (long) -(num33 >> 1));
      this.zint_co_reduce_mod(usrc, a1, tmpsrc, num1, ysrc, y, len, m0i2, xa2, xb2, ya2, yb2);
      this.zint_co_reduce_mod(vsrc, a2, tmpsrc, index1, xsrc, x, len, m0i1, xa2, xb2, ya2, yb2);
    }
    uint num34 = tmpsrc[index2] ^ 1U;
    for (int index7 = 1; index7 < len; ++index7)
      num34 |= tmpsrc[index2 + index7];
    return (int) (1L - (((long) num34 | (long) -num34) >> 31 /*0x1F*/) & (long) xsrc[x] & (long) ysrc[y]);
  }

  internal void zint_add_scaled_mul_small(
    uint[] xsrc,
    int x,
    int xlen,
    uint[] ysrc,
    int y,
    int ylen,
    int k,
    uint sch,
    uint scl)
  {
    if (ylen == 0)
      return;
    uint num1 = -(ysrc[y + ylen - 1] >> 30) >> 1;
    uint num2 = 0;
    int num3 = 0;
    for (int index = (int) sch; index < xlen; ++index)
    {
      int num4 = index - (int) sch;
      int num5 = num4 < ylen ? (int) ysrc[y + num4] : (int) num1;
      uint num6 = (uint) (num5 << (int) scl & int.MaxValue) | num2;
      num2 = (uint) (num5 >>> 31 /*0x1F*/ - (int) scl);
      ulong num7 = (ulong) num6 * (ulong) k + (ulong) xsrc[x + index] + (ulong) num3;
      xsrc[x + index] = (uint) num7 & (uint) int.MaxValue;
      num3 = (int) (uint) (num7 >> 31 /*0x1F*/);
    }
  }

  internal void zint_sub_scaled(
    uint[] xsrc,
    int x,
    int xlen,
    uint[] ysrc,
    int y,
    int ylen,
    uint sch,
    uint scl)
  {
    if (ylen == 0)
      return;
    uint num1 = (uint) ((ulong) -(ysrc[y + ylen - 1] >> 30) >> 1);
    uint num2 = 0;
    uint num3 = 0;
    for (int index = (int) sch; index < xlen; ++index)
    {
      int num4 = index - (int) sch;
      int num5 = num4 < ylen ? (int) ysrc[y + num4] : (int) num1;
      uint num6 = (uint) (num5 << (int) scl & int.MaxValue) | num2;
      num2 = (uint) (num5 >>> 31 /*0x1F*/ - (int) scl);
      uint num7 = xsrc[x + index] - num6 - num3;
      xsrc[x + index] = num7 & (uint) int.MaxValue;
      num3 = num7 >> 31 /*0x1F*/;
    }
  }

  internal int zint_one_to_plain(uint[] xsrc, int x)
  {
    int num = (int) xsrc[x];
    return num | (num & 1073741824 /*0x40000000*/) << 1;
  }

  internal void poly_big_to_fp(
    FalconFPR[] dsrc,
    int d,
    uint[] fsrc,
    int f,
    int flen,
    int fstride,
    uint logn)
  {
    int num1 = 1 << (int) logn;
    if (flen == 0)
    {
      for (int index = 0; index < num1; ++index)
        dsrc[d + index] = this.fpre.fpr_zero;
    }
    else
    {
      int num2 = 0;
      while (num2 < num1)
      {
        uint num3 = -(fsrc[f + flen - 1] >> 30);
        uint num4 = num3 >> 1;
        uint num5 = num3 & 1U;
        FalconFPR x = this.fpre.fpr_zero;
        FalconFPR falconFpr = this.fpre.fpr_one;
        int num6 = 0;
        while (num6 < flen)
        {
          uint num7 = (fsrc[f + num6] ^ num4) + num5;
          num5 = num7 >> 31 /*0x1F*/;
          uint num8 = num7 & (uint) int.MaxValue;
          uint i = num8 - (num8 << 1 & num3);
          x = this.fpre.fpr_add(x, this.fpre.fpr_mul(this.fpre.fpr_of((long) (int) i), falconFpr));
          ++num6;
          falconFpr = this.fpre.fpr_mul(falconFpr, this.fpre.fpr_ptwo31);
        }
        dsrc[d + num2] = x;
        ++num2;
        f += fstride;
      }
    }
  }

  internal int poly_big_to_small(sbyte[] dsrc, int d, uint[] ssrc, int s, int lim, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = 0; index < num; ++index)
    {
      int plain = this.zint_one_to_plain(ssrc, s + index);
      if (plain < -lim || plain > lim)
        return 0;
      dsrc[d + index] = (sbyte) plain;
    }
    return 1;
  }

  internal void poly_sub_scaled(
    uint[] Fsrc,
    int F,
    int Flen,
    int Fstride,
    uint[] fsrc,
    int f,
    int flen,
    int fstride,
    int[] ksrc,
    int k,
    uint sch,
    uint scl,
    uint logn)
  {
    int num = 1 << (int) logn;
    for (int index1 = 0; index1 < num; ++index1)
    {
      int k1 = -ksrc[k + index1];
      int x = F + index1 * Fstride;
      int y = f;
      for (int index2 = 0; index2 < num; ++index2)
      {
        this.zint_add_scaled_mul_small(Fsrc, x, Flen, fsrc, y, flen, k1, sch, scl);
        if (index1 + index2 == num - 1)
        {
          x = F;
          k1 = -k1;
        }
        else
          x += Fstride;
        y += fstride;
      }
    }
  }

  internal void poly_sub_scaled_ntt(
    uint[] Fsrc,
    int F,
    int Flen,
    int Fstride,
    uint[] fsrc,
    int f,
    int flen,
    int fstride,
    int[] ksrc,
    int k,
    uint sch,
    uint scl,
    uint logn,
    uint[] tmpsrc,
    int tmp)
  {
    int num1 = 1 << (int) logn;
    int num2 = flen + 1;
    int gm = tmp;
    int igm = gm + num1;
    int xx = igm + num1;
    int num3 = xx + num1 * num2;
    FalconSmallPrime[] primes = this.PRIMES;
    for (int index1 = 0; index1 < num2; ++index1)
    {
      uint p = primes[index1].p;
      uint p0i = this.modp_ninv31(p);
      uint num4 = this.modp_R2(p, p0i);
      uint Rx = this.modp_Rx((uint) flen, p, p0i, num4);
      this.modp_mkgm2(tmpsrc, gm, tmpsrc, igm, logn, primes[index1].g, p, p0i);
      for (int index2 = 0; index2 < num1; ++index2)
        tmpsrc[num3 + index2] = this.modp_set(ksrc[k + index2], p);
      this.modp_NTT2(tmpsrc, num3, tmpsrc, gm, logn, p, p0i);
      int num5 = 0;
      int d = f;
      int index3 = xx + index1;
      while (num5 < num1)
      {
        tmpsrc[index3] = this.zint_mod_small_signed(tmpsrc, d, flen, p, p0i, num4, Rx);
        ++num5;
        d += fstride;
        index3 += num2;
      }
      this.modp_NTT2_ext(tmpsrc, xx + index1, num2, tmpsrc, gm, logn, p, p0i);
      int num6 = 0;
      int index4 = xx + index1;
      while (num6 < num1)
      {
        tmpsrc[index4] = this.modp_montymul(this.modp_montymul(tmpsrc[num3 + num6], tmpsrc[index4], p, p0i), num4, p, p0i);
        ++num6;
        index4 += num2;
      }
      this.modp_iNTT2_ext(tmpsrc, xx + index1, num2, tmpsrc, igm, logn, p, p0i);
    }
    this.zint_rebuild_CRT(tmpsrc, xx, num2, num2, num1, primes, 1, tmpsrc, num3);
    int num7 = 0;
    int x = F;
    int y = xx;
    while (num7 < num1)
    {
      this.zint_sub_scaled(tmpsrc, x, Flen, tmpsrc, y, num2, sch, scl);
      ++num7;
      x += Fstride;
      y += num2;
    }
  }

  internal ulong get_rng_u64(SHAKE256 rng)
  {
    byte[] outsrc = new byte[8];
    rng.i_shake256_extract(outsrc, 0, 8);
    return (ulong) ((long) outsrc[0] | (long) outsrc[1] << 8 | (long) outsrc[2] << 16 /*0x10*/ | (long) outsrc[3] << 24 | (long) outsrc[4] << 32 /*0x20*/ | (long) outsrc[5] << 40 | (long) outsrc[6] << 48 /*0x30*/ | (long) outsrc[7] << 56);
  }

  internal int mkgauss(SHAKE256 rng, uint logn)
  {
    uint num1 = (uint) (1 << 10 - (int) logn);
    int num2 = 0;
    for (uint index1 = 0; index1 < num1; ++index1)
    {
      ulong rngU64 = this.get_rng_u64(rng);
      uint num3 = (uint) (rngU64 >> 63 /*0x3F*/);
      uint num4 = (uint) ((rngU64 & (ulong) long.MaxValue) - this.gauss_1024_12289[0] >> 63 /*0x3F*/);
      uint num5 = 0;
      ulong num6 = this.get_rng_u64(rng) & (ulong) long.MaxValue;
      for (uint index2 = 1; (long) index2 < (long) this.gauss_1024_12289.Length; ++index2)
      {
        uint num7 = (uint) (num6 - this.gauss_1024_12289[(int) index2] >> 63 /*0x3F*/) ^ 1U;
        num5 |= (uint) ((ulong) index2 & (ulong) -(num7 & (num4 ^ 1U)));
        num4 |= num7;
      }
      uint num8 = (uint) (((ulong) num5 ^ (ulong) -num3) + (ulong) num3);
      num2 += (int) num8;
    }
    return num2;
  }

  internal uint poly_small_sqnorm(sbyte[] fsrc, int f, uint logn)
  {
    int num1 = 1 << (int) logn;
    uint num2 = 0;
    uint num3 = 0;
    for (int index = 0; index < num1; ++index)
    {
      int num4 = (int) fsrc[f + index];
      num2 += (uint) (num4 * num4);
      num3 |= num2;
    }
    return (uint) ((ulong) num2 | (ulong) -(num3 >> 31 /*0x1F*/));
  }

  internal void poly_small_to_fp(FalconFPR[] xsrc, int x, sbyte[] fsrc, int f, uint logn)
  {
    int num = 1 << (int) logn;
    for (int index = 0; index < num; ++index)
      xsrc[x + index] = this.fpre.fpr_of((long) fsrc[f + index]);
  }

  internal void make_fg_step(
    uint[] datasrc,
    int data,
    uint logn,
    uint depth,
    int in_ntt,
    int out_ntt)
  {
    int num1 = 1 << (int) logn;
    int num2 = num1 >> 1;
    int num3 = this.MAX_BL_SMALL[(int) depth];
    int stride = this.MAX_BL_SMALL[(int) depth + 1];
    FalconSmallPrime[] primes = this.PRIMES;
    int num4 = data;
    int num5 = num4 + num2 * stride;
    int num6 = num5 + num2 * stride;
    int xx = num6 + num1 * num3;
    int num7 = xx + num1 * num3;
    int igm = num7 + num1;
    int a1 = igm + num1;
    Array.Copy((Array) datasrc, data, (Array) datasrc, num6, 2 * num1 * num3);
    for (int index1 = 0; index1 < num3; ++index1)
    {
      uint p = primes[index1].p;
      uint p0i = this.modp_ninv31(p);
      uint b1 = this.modp_R2(p, p0i);
      this.modp_mkgm2(datasrc, num7, datasrc, igm, logn, primes[index1].g, p, p0i);
      int num8 = 0;
      int index2 = num6 + index1;
      while (num8 < num1)
      {
        datasrc[a1 + num8] = datasrc[index2];
        ++num8;
        index2 += num3;
      }
      if (in_ntt == 0)
        this.modp_NTT2(datasrc, a1, datasrc, num7, logn, p, p0i);
      int num9 = 0;
      int index3 = num4 + index1;
      while (num9 < num2)
      {
        uint a2 = datasrc[a1 + (num9 << 1)];
        uint b2 = datasrc[a1 + (num9 << 1) + 1];
        datasrc[index3] = this.modp_montymul(this.modp_montymul(a2, b2, p, p0i), b1, p, p0i);
        ++num9;
        index3 += stride;
      }
      if (in_ntt != 0)
        this.modp_iNTT2_ext(datasrc, num6 + index1, num3, datasrc, igm, logn, p, p0i);
      int num10 = 0;
      int index4 = xx + index1;
      while (num10 < num1)
      {
        datasrc[a1 + num10] = datasrc[index4];
        ++num10;
        index4 += num3;
      }
      if (in_ntt == 0)
        this.modp_NTT2(datasrc, a1, datasrc, num7, logn, p, p0i);
      int num11 = 0;
      int index5 = num5 + index1;
      while (num11 < num2)
      {
        uint a3 = datasrc[a1 + (num11 << 1)];
        uint b3 = datasrc[a1 + (num11 << 1) + 1];
        datasrc[index5] = this.modp_montymul(this.modp_montymul(a3, b3, p, p0i), b1, p, p0i);
        ++num11;
        index5 += stride;
      }
      if (in_ntt != 0)
        this.modp_iNTT2_ext(datasrc, xx + index1, num3, datasrc, igm, logn, p, p0i);
      if (out_ntt == 0)
      {
        this.modp_iNTT2_ext(datasrc, num4 + index1, stride, datasrc, igm, logn - 1U, p, p0i);
        this.modp_iNTT2_ext(datasrc, num5 + index1, stride, datasrc, igm, logn - 1U, p, p0i);
      }
    }
    this.zint_rebuild_CRT(datasrc, num6, num3, num3, num1, primes, 1, datasrc, num7);
    this.zint_rebuild_CRT(datasrc, xx, num3, num3, num1, primes, 1, datasrc, num7);
    for (int index6 = num3; index6 < stride; ++index6)
    {
      uint p = primes[index6].p;
      uint p0i = this.modp_ninv31(p);
      uint num12 = this.modp_R2(p, p0i);
      uint Rx = this.modp_Rx((uint) num3, p, p0i, num12);
      this.modp_mkgm2(datasrc, num7, datasrc, igm, logn, primes[index6].g, p, p0i);
      int num13 = 0;
      int d1 = num6;
      while (num13 < num1)
      {
        datasrc[a1 + num13] = this.zint_mod_small_signed(datasrc, d1, num3, p, p0i, num12, Rx);
        ++num13;
        d1 += num3;
      }
      this.modp_NTT2(datasrc, a1, datasrc, num7, logn, p, p0i);
      int num14 = 0;
      int index7 = num4 + index6;
      while (num14 < num2)
      {
        uint a4 = datasrc[a1 + (num14 << 1)];
        uint b = datasrc[a1 + (num14 << 1) + 1];
        datasrc[index7] = this.modp_montymul(this.modp_montymul(a4, b, p, p0i), num12, p, p0i);
        ++num14;
        index7 += stride;
      }
      int num15 = 0;
      int d2 = xx;
      while (num15 < num1)
      {
        datasrc[a1 + num15] = this.zint_mod_small_signed(datasrc, d2, num3, p, p0i, num12, Rx);
        ++num15;
        d2 += num3;
      }
      this.modp_NTT2(datasrc, a1, datasrc, num7, logn, p, p0i);
      int num16 = 0;
      int index8 = num5 + index6;
      while (num16 < num2)
      {
        uint a5 = datasrc[a1 + (num16 << 1)];
        uint b = datasrc[a1 + (num16 << 1) + 1];
        datasrc[index8] = this.modp_montymul(this.modp_montymul(a5, b, p, p0i), num12, p, p0i);
        ++num16;
        index8 += stride;
      }
      if (out_ntt == 0)
      {
        this.modp_iNTT2_ext(datasrc, num4 + index6, stride, datasrc, igm, logn - 1U, p, p0i);
        this.modp_iNTT2_ext(datasrc, num5 + index6, stride, datasrc, igm, logn - 1U, p, p0i);
      }
    }
  }

  internal void make_fg(
    uint[] datasrc,
    int data,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    uint logn,
    uint depth,
    int out_ntt)
  {
    int num = 1 << (int) logn;
    int a1 = data;
    int a2 = a1 + num;
    FalconSmallPrime[] primes = this.PRIMES;
    uint p1 = primes[0].p;
    for (int index = 0; index < num; ++index)
    {
      datasrc[a1 + index] = this.modp_set((int) fsrc[f + index], p1);
      datasrc[a2 + index] = this.modp_set((int) gsrc[g + index], p1);
    }
    if (depth == 0U && out_ntt != 0)
    {
      uint p2 = primes[0].p;
      uint p0i = this.modp_ninv31(p2);
      int gm = a2 + num;
      int igm = gm + num;
      this.modp_mkgm2(datasrc, gm, datasrc, igm, logn, primes[0].g, p2, p0i);
      this.modp_NTT2(datasrc, a1, datasrc, gm, logn, p2, p0i);
      this.modp_NTT2(datasrc, a2, datasrc, gm, logn, p2, p0i);
    }
    else
    {
      for (uint depth1 = 0; depth1 < depth; ++depth1)
        this.make_fg_step(datasrc, data, logn - depth1, depth1, depth1 != 0U ? 1 : 0, depth1 + 1U < depth || out_ntt != 0 ? 1 : 0);
    }
  }

  internal int solve_NTRU_deepest(
    uint logn_top,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    uint[] tmpsrc,
    int tmp)
  {
    int num1 = this.MAX_BL_SMALL[(int) logn_top];
    FalconSmallPrime[] primes = this.PRIMES;
    int num2 = tmp;
    int num3 = num2 + num1;
    int num4 = num3 + num1;
    int y = num4 + num1;
    int tmp1 = y + num1;
    this.make_fg(tmpsrc, num4, fsrc, f, gsrc, g, logn_top, logn_top, 0);
    this.zint_rebuild_CRT(tmpsrc, num4, num1, num1, 2, primes, 0, tmpsrc, tmp1);
    if (this.zint_bezout(tmpsrc, num3, tmpsrc, num2, tmpsrc, num4, tmpsrc, y, num1, tmpsrc, tmp1) == 0)
      return 0;
    uint x = 12289;
    return this.zint_mul_small(tmpsrc, num2, num1, 12289U) == 0U && this.zint_mul_small(tmpsrc, num3, num1, x) == 0U ? 1 : 0;
  }

  internal int solve_NTRU_intermediate(
    uint logn_top,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    uint depth,
    uint[] tmpsrc,
    int tmp)
  {
    uint logn = logn_top - depth;
    int num1 = 1 << (int) logn;
    int num2 = num1 >> 1;
    int num3 = this.MAX_BL_SMALL[(int) depth];
    int num4 = this.MAX_BL_SMALL[(int) depth + 1];
    int num5 = this.MAX_BL_LARGE[(int) depth];
    FalconSmallPrime[] primes = this.PRIMES;
    int sourceIndex1 = tmp;
    int num6 = sourceIndex1 + num4 * num2 + num4 * num2;
    this.make_fg(tmpsrc, num6, fsrc, f, gsrc, g, logn_top, depth, 1);
    int num7 = tmp;
    int num8 = num7 + num1 * num5;
    int destinationIndex1 = num8 + num1 * num5;
    Array.Copy((Array) tmpsrc, num6, (Array) tmpsrc, destinationIndex1, 2 * num1 * num3);
    int num9 = destinationIndex1;
    int num10 = num9 + num3 * num1;
    int num11 = num10 + num3 * num1;
    Array.Copy((Array) tmpsrc, sourceIndex1, (Array) tmpsrc, num11, 2 * num2 * num4);
    int num12 = num11;
    int num13 = num12 + num2 * num4;
    for (int index1 = 0; index1 < num5; ++index1)
    {
      uint p = primes[index1].p;
      uint p0i = this.modp_ninv31(p);
      uint R2 = this.modp_R2(p, p0i);
      uint Rx = this.modp_Rx((uint) num4, p, p0i, R2);
      int num14 = 0;
      int d1 = num12;
      int d2 = num13;
      int index2 = num7 + index1;
      int index3 = num8 + index1;
      while (num14 < num2)
      {
        tmpsrc[index2] = this.zint_mod_small_signed(tmpsrc, d1, num4, p, p0i, R2, Rx);
        tmpsrc[index3] = this.zint_mod_small_signed(tmpsrc, d2, num4, p, p0i, R2, Rx);
        ++num14;
        d1 += num4;
        d2 += num4;
        index2 += num5;
        index3 += num5;
      }
    }
    for (int index4 = 0; index4 < num5; ++index4)
    {
      uint p = primes[index4].p;
      uint p0i = this.modp_ninv31(p);
      uint num15 = this.modp_R2(p, p0i);
      if (index4 == num3)
      {
        this.zint_rebuild_CRT(tmpsrc, num9, num3, num3, num1, primes, 1, tmpsrc, num11);
        this.zint_rebuild_CRT(tmpsrc, num10, num3, num3, num1, primes, 1, tmpsrc, num11);
      }
      int gm = num11;
      int igm = gm + num1;
      int a1 = igm + num1;
      int a2 = a1 + num1;
      this.modp_mkgm2(tmpsrc, gm, tmpsrc, igm, logn, primes[index4].g, p, p0i);
      if (index4 < num3)
      {
        int num16 = 0;
        int index5 = num9 + index4;
        int index6 = num10 + index4;
        while (num16 < num1)
        {
          tmpsrc[a1 + num16] = tmpsrc[index5];
          tmpsrc[a2 + num16] = tmpsrc[index6];
          ++num16;
          index5 += num3;
          index6 += num3;
        }
        this.modp_iNTT2_ext(tmpsrc, num9 + index4, num3, tmpsrc, igm, logn, p, p0i);
        this.modp_iNTT2_ext(tmpsrc, num10 + index4, num3, tmpsrc, igm, logn, p, p0i);
      }
      else
      {
        uint Rx = this.modp_Rx((uint) num3, p, p0i, num15);
        int num17 = 0;
        int d3 = num9;
        int d4 = num10;
        while (num17 < num1)
        {
          tmpsrc[a1 + num17] = this.zint_mod_small_signed(tmpsrc, d3, num3, p, p0i, num15, Rx);
          tmpsrc[a2 + num17] = this.zint_mod_small_signed(tmpsrc, d4, num3, p, p0i, num15, Rx);
          ++num17;
          d3 += num3;
          d4 += num3;
        }
        this.modp_NTT2(tmpsrc, a1, tmpsrc, gm, logn, p, p0i);
        this.modp_NTT2(tmpsrc, a2, tmpsrc, gm, logn, p, p0i);
      }
      int a3 = a2 + num1;
      int a4 = a3 + num2;
      int num18 = 0;
      int index7 = num7 + index4;
      int index8 = num8 + index4;
      while (num18 < num2)
      {
        tmpsrc[a3 + num18] = tmpsrc[index7];
        tmpsrc[a4 + num18] = tmpsrc[index8];
        ++num18;
        index7 += num5;
        index8 += num5;
      }
      this.modp_NTT2(tmpsrc, a3, tmpsrc, gm, logn - 1U, p, p0i);
      this.modp_NTT2(tmpsrc, a4, tmpsrc, gm, logn - 1U, p, p0i);
      int num19 = 0;
      int index9 = num7 + index4;
      int index10 = num8 + index4;
      while (num19 < num2)
      {
        uint a5 = tmpsrc[a1 + (num19 << 1)];
        uint a6 = tmpsrc[a1 + (num19 << 1) + 1];
        uint a7 = tmpsrc[a2 + (num19 << 1)];
        uint a8 = tmpsrc[a2 + (num19 << 1) + 1];
        uint b1 = this.modp_montymul(tmpsrc[a3 + num19], num15, p, p0i);
        uint b2 = this.modp_montymul(tmpsrc[a4 + num19], num15, p, p0i);
        tmpsrc[index9] = this.modp_montymul(a8, b1, p, p0i);
        tmpsrc[index9 + num5] = this.modp_montymul(a7, b1, p, p0i);
        tmpsrc[index10] = this.modp_montymul(a6, b2, p, p0i);
        tmpsrc[index10 + num5] = this.modp_montymul(a5, b2, p, p0i);
        ++num19;
        index9 += num5 << 1;
        index10 += num5 << 1;
      }
      this.modp_iNTT2_ext(tmpsrc, num7 + index4, num5, tmpsrc, igm, logn, p, p0i);
      this.modp_iNTT2_ext(tmpsrc, num8 + index4, num5, tmpsrc, igm, logn, p, p0i);
    }
    this.zint_rebuild_CRT(tmpsrc, num7, num5, num5, num1, primes, 1, tmpsrc, num11);
    this.zint_rebuild_CRT(tmpsrc, num8, num5, num5, num1, primes, 1, tmpsrc, num11);
    FalconFPR[] falconFprArray1 = new FalconFPR[num1];
    FalconFPR[] falconFprArray2 = new FalconFPR[num1];
    FalconFPR[] falconFprArray3 = new FalconFPR[num1];
    FalconFPR[] falconFprArray4 = new FalconFPR[num1];
    FalconFPR[] falconFprArray5 = new FalconFPR[num1 >> 1];
    int[] ksrc = new int[num1];
    int flen1 = num3 > 10 ? 10 : num3;
    this.poly_big_to_fp(falconFprArray3, 0, tmpsrc, num9 + num3 - flen1, flen1, num3, logn);
    this.poly_big_to_fp(falconFprArray4, 0, tmpsrc, num10 + num3 - flen1, flen1, num3, logn);
    int num20 = 31 /*0x1F*/ * (num3 - flen1);
    int num21 = this.BITLENGTH_avg[(int) depth] - 6 * this.BITLENGTH_std[(int) depth];
    int num22 = this.BITLENGTH_avg[(int) depth] + 6 * this.BITLENGTH_std[(int) depth];
    this.ffte.FFT(falconFprArray3, 0, logn);
    this.ffte.FFT(falconFprArray4, 0, logn);
    this.ffte.poly_invnorm2_fft(falconFprArray5, 0, falconFprArray3, 0, falconFprArray4, 0, logn);
    this.ffte.poly_adj_fft(falconFprArray3, 0, logn);
    this.ffte.poly_adj_fft(falconFprArray4, 0, logn);
    int Flen = num5;
    int num23 = 31 /*0x1F*/ * num5;
    int num24 = num23 - num21;
    while (true)
    {
      do
      {
        int flen2 = Flen > 10 ? 10 : Flen;
        int num25 = 31 /*0x1F*/ * (Flen - flen2);
        this.poly_big_to_fp(falconFprArray1, 0, tmpsrc, num7 + Flen - flen2, flen2, num5, logn);
        this.poly_big_to_fp(falconFprArray2, 0, tmpsrc, num8 + Flen - flen2, flen2, num5, logn);
        this.ffte.FFT(falconFprArray1, 0, logn);
        this.ffte.FFT(falconFprArray2, 0, logn);
        this.ffte.poly_mul_fft(falconFprArray1, 0, falconFprArray3, 0, logn);
        this.ffte.poly_mul_fft(falconFprArray2, 0, falconFprArray4, 0, logn);
        this.ffte.poly_add(falconFprArray2, 0, falconFprArray1, 0, logn);
        this.ffte.poly_mul_autoadj_fft(falconFprArray2, 0, falconFprArray5, 0, logn);
        this.ffte.iFFT(falconFprArray2, 0, logn);
        int num26 = num24 - num25 + num20;
        FalconFPR falconFpr1;
        if (num26 < 0)
        {
          num26 = -num26;
          falconFpr1 = this.fpre.fpr_two;
        }
        else
          falconFpr1 = this.fpre.fpr_onehalf;
        FalconFPR falconFpr2 = this.fpre.fpr_one;
        while (num26 != 0)
        {
          if ((num26 & 1) != 0)
            falconFpr2 = this.fpre.fpr_mul(falconFpr2, falconFpr1);
          num26 >>= 1;
          falconFpr1 = this.fpre.fpr_sqr(falconFpr1);
        }
        for (int index = 0; index < num1; ++index)
        {
          FalconFPR falconFpr3 = this.fpre.fpr_mul(falconFprArray2[index], falconFpr2);
          if (!this.fpre.fpr_lt(this.fpre.fpr_mtwo31m1, falconFpr3) || !this.fpre.fpr_lt(falconFpr3, this.fpre.fpr_ptwo31m1))
            return 0;
          ksrc[index] = (int) this.fpre.fpr_rint(falconFpr3);
        }
        uint sch = (uint) (num24 / 31 /*0x1F*/);
        uint scl = (uint) (num24 % 31 /*0x1F*/);
        if (depth <= 4U)
        {
          this.poly_sub_scaled_ntt(tmpsrc, num7, Flen, num5, tmpsrc, num9, num3, num3, ksrc, 0, sch, scl, logn, tmpsrc, num11);
          this.poly_sub_scaled_ntt(tmpsrc, num8, Flen, num5, tmpsrc, num10, num3, num3, ksrc, 0, sch, scl, logn, tmpsrc, num11);
        }
        else
        {
          this.poly_sub_scaled(tmpsrc, num7, Flen, num5, tmpsrc, num9, num3, num3, ksrc, 0, sch, scl, logn);
          this.poly_sub_scaled(tmpsrc, num8, Flen, num5, tmpsrc, num10, num3, num3, ksrc, 0, sch, scl, logn);
        }
        int num27 = num24 + num22 + 10;
        if (num27 < num23)
        {
          num23 = num27;
          if (Flen * 31 /*0x1F*/ >= num23 + 31 /*0x1F*/)
            --Flen;
        }
        if (num24 > 0)
          num24 -= 25;
        else
          goto label_48;
      }
      while (num24 >= 0);
      num24 = 0;
    }
label_48:
    if (Flen < num3)
    {
      int num28 = 0;
      while (num28 < num1)
      {
        uint num29 = -(tmpsrc[num7 + Flen - 1] >> 30) >> 1;
        for (int index = Flen; index < num3; ++index)
          tmpsrc[num7 + index] = num29;
        uint num30 = -(tmpsrc[num8 + Flen - 1] >> 30) >> 1;
        for (int index = Flen; index < num3; ++index)
          tmpsrc[num8 + index] = num30;
        ++num28;
        num7 += num5;
        num8 += num5;
      }
    }
    int num31 = 0;
    int destinationIndex2 = tmp;
    int sourceIndex2 = tmp;
    while (num31 < num1 << 1)
    {
      Array.Copy((Array) tmpsrc, sourceIndex2, (Array) tmpsrc, destinationIndex2, num3);
      ++num31;
      destinationIndex2 += num3;
      sourceIndex2 += num5;
    }
    return 1;
  }

  internal int solve_NTRU_binary_depth1(
    uint logn_top,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    uint[] tmpsrc,
    int tmp)
  {
    uint num1 = 1;
    int num2 = 1 << (int) logn_top;
    uint logn1 = logn_top - 1U;
    int length = 1 << (int) logn1;
    int num3 = length >> 1;
    int num4 = this.MAX_BL_SMALL[1];
    int num5 = this.MAX_BL_SMALL[2];
    int num6 = this.MAX_BL_LARGE[1];
    int num7 = tmp;
    int num8 = num7 + num5 * num3;
    int sourceIndex1 = num8 + num5 * num3;
    int sourceIndex2 = sourceIndex1 + num6 * length;
    for (int index1 = 0; index1 < num6; ++index1)
    {
      uint p = this.PRIMES[index1].p;
      uint p0i = this.modp_ninv31(p);
      uint R2 = this.modp_R2(p, p0i);
      uint Rx = this.modp_Rx((uint) num5, p, p0i, R2);
      int num9 = 0;
      int d1 = num7;
      int d2 = num8;
      int index2 = sourceIndex1 + index1;
      int index3 = sourceIndex2 + index1;
      while (num9 < num3)
      {
        tmpsrc[index2] = this.zint_mod_small_signed(tmpsrc, d1, num5, p, p0i, R2, Rx);
        tmpsrc[index3] = this.zint_mod_small_signed(tmpsrc, d2, num5, p, p0i, R2, Rx);
        ++num9;
        d1 += num5;
        d2 += num5;
        index2 += num6;
        index3 += num6;
      }
    }
    Array.Copy((Array) tmpsrc, sourceIndex1, (Array) tmpsrc, tmp, num6 * length);
    int num10 = tmp;
    Array.Copy((Array) tmpsrc, sourceIndex2, (Array) tmpsrc, num10 + num6 * length, num6 * length);
    int f1 = num10 + num6 * length;
    int num11 = f1 + num6 * length;
    int num12 = num11 + num4 * length;
    int tmp1 = num12 + num4 * length;
    for (int index4 = 0; index4 < num6; ++index4)
    {
      uint p = this.PRIMES[index4].p;
      uint p0i = this.modp_ninv31(p);
      uint num13 = this.modp_R2(p, p0i);
      int gm = tmp1;
      int num14 = gm + num2;
      int num15 = num14 + length;
      int num16 = num15 + num2;
      this.modp_mkgm2(tmpsrc, gm, tmpsrc, num14, logn_top, this.PRIMES[index4].g, p, p0i);
      for (int index5 = 0; index5 < num2; ++index5)
      {
        tmpsrc[num15 + index5] = this.modp_set((int) fsrc[f + index5], p);
        tmpsrc[num16 + index5] = this.modp_set((int) gsrc[g + index5], p);
      }
      this.modp_NTT2(tmpsrc, num15, tmpsrc, gm, logn_top, p, p0i);
      this.modp_NTT2(tmpsrc, num16, tmpsrc, gm, logn_top, p, p0i);
      for (uint logn2 = logn_top; logn2 > logn1; --logn2)
      {
        this.modp_poly_rec_res(tmpsrc, num15, logn2, p, p0i, num13);
        this.modp_poly_rec_res(tmpsrc, num16, logn2, p, p0i, num13);
      }
      if (num1 > 0U)
      {
        Array.Copy((Array) tmpsrc, num14, (Array) tmpsrc, gm + length, length);
        num14 = gm + length;
        Array.Copy((Array) tmpsrc, num15, (Array) tmpsrc, num14 + length, length);
        num15 = num14 + length;
        Array.Copy((Array) tmpsrc, num16, (Array) tmpsrc, num15 + length, length);
        num16 = num15 + length;
      }
      int a1 = num16 + length;
      int a2 = a1 + num3;
      int num17 = 0;
      int index6 = num10 + index4;
      int index7 = f1 + index4;
      while (num17 < num3)
      {
        tmpsrc[a1 + num17] = tmpsrc[index6];
        tmpsrc[a2 + num17] = tmpsrc[index7];
        ++num17;
        index6 += num6;
        index7 += num6;
      }
      this.modp_NTT2(tmpsrc, a1, tmpsrc, gm, logn1 - 1U, p, p0i);
      this.modp_NTT2(tmpsrc, a2, tmpsrc, gm, logn1 - 1U, p, p0i);
      int num18 = 0;
      int index8 = num10 + index4;
      int index9 = f1 + index4;
      while (num18 < num3)
      {
        uint a3 = tmpsrc[num15 + (num18 << 1)];
        uint a4 = tmpsrc[num15 + (num18 << 1) + 1];
        uint a5 = tmpsrc[num16 + (num18 << 1)];
        uint a6 = tmpsrc[num16 + (num18 << 1) + 1];
        uint b1 = this.modp_montymul(tmpsrc[a1 + num18], num13, p, p0i);
        uint b2 = this.modp_montymul(tmpsrc[a2 + num18], num13, p, p0i);
        tmpsrc[index8] = this.modp_montymul(a6, b1, p, p0i);
        tmpsrc[index8 + num6] = this.modp_montymul(a5, b1, p, p0i);
        tmpsrc[index9] = this.modp_montymul(a4, b2, p, p0i);
        tmpsrc[index9 + num6] = this.modp_montymul(a3, b2, p, p0i);
        ++num18;
        index8 += num6 << 1;
        index9 += num6 << 1;
      }
      this.modp_iNTT2_ext(tmpsrc, num10 + index4, num6, tmpsrc, num14, logn1, p, p0i);
      this.modp_iNTT2_ext(tmpsrc, f1 + index4, num6, tmpsrc, num14, logn1, p, p0i);
      if (index4 < num4)
      {
        this.modp_iNTT2(tmpsrc, num15, tmpsrc, num14, logn1, p, p0i);
        this.modp_iNTT2(tmpsrc, num16, tmpsrc, num14, logn1, p, p0i);
        int num19 = 0;
        int index10 = num11 + index4;
        int index11 = num12 + index4;
        while (num19 < length)
        {
          tmpsrc[index10] = tmpsrc[num15 + num19];
          tmpsrc[index11] = tmpsrc[num16 + num19];
          ++num19;
          index10 += num4;
          index11 += num4;
        }
      }
    }
    this.zint_rebuild_CRT(tmpsrc, num10, num6, num6, length << 1, this.PRIMES, 1, tmpsrc, tmp1);
    this.zint_rebuild_CRT(tmpsrc, num11, num4, num4, length << 1, this.PRIMES, 1, tmpsrc, tmp1);
    FalconFPR[] falconFprArray1 = new FalconFPR[length];
    FalconFPR[] falconFprArray2 = new FalconFPR[length];
    this.poly_big_to_fp(falconFprArray1, 0, tmpsrc, num10, num6, num6, logn1);
    this.poly_big_to_fp(falconFprArray2, 0, tmpsrc, f1, num6, num6, logn1);
    Array.Copy((Array) tmpsrc, num11, (Array) tmpsrc, tmp, 2 * num4 * length);
    int f2 = tmp;
    int f3 = f2 + num4 * length;
    FalconFPR[] falconFprArray3 = new FalconFPR[length];
    FalconFPR[] falconFprArray4 = new FalconFPR[length];
    this.poly_big_to_fp(falconFprArray3, 0, tmpsrc, f2, num4, num4, logn1);
    this.poly_big_to_fp(falconFprArray4, 0, tmpsrc, f3, num4, num4, logn1);
    this.ffte.FFT(falconFprArray1, 0, logn1);
    this.ffte.FFT(falconFprArray2, 0, logn1);
    this.ffte.FFT(falconFprArray3, 0, logn1);
    this.ffte.FFT(falconFprArray4, 0, logn1);
    FalconFPR[] falconFprArray5 = new FalconFPR[length];
    FalconFPR[] falconFprArray6 = new FalconFPR[length];
    this.ffte.poly_add_muladj_fft(falconFprArray5, 0, falconFprArray1, 0, falconFprArray2, 0, falconFprArray3, 0, falconFprArray4, 0, logn1);
    this.ffte.poly_invnorm2_fft(falconFprArray6, 0, falconFprArray3, 0, falconFprArray4, 0, logn1);
    this.ffte.poly_mul_autoadj_fft(falconFprArray5, 0, falconFprArray6, 0, logn1);
    this.ffte.iFFT(falconFprArray5, 0, logn1);
    for (int index = 0; index < length; ++index)
    {
      FalconFPR falconFpr = falconFprArray5[index];
      if (!this.fpre.fpr_lt(falconFpr, this.fpre.fpr_ptwo63m1) || !this.fpre.fpr_lt(this.fpre.fpr_mtwo63m1, falconFpr))
        return 0;
      falconFprArray5[index] = this.fpre.fpr_of(this.fpre.fpr_rint(falconFpr));
    }
    this.ffte.FFT(falconFprArray5, 0, logn1);
    this.ffte.poly_mul_fft(falconFprArray3, 0, falconFprArray5, 0, logn1);
    this.ffte.poly_mul_fft(falconFprArray4, 0, falconFprArray5, 0, logn1);
    this.ffte.poly_sub(falconFprArray1, 0, falconFprArray3, 0, logn1);
    this.ffte.poly_sub(falconFprArray2, 0, falconFprArray4, 0, logn1);
    this.ffte.iFFT(falconFprArray1, 0, logn1);
    this.ffte.iFFT(falconFprArray2, 0, logn1);
    int num20 = tmp;
    int num21 = num20 + length;
    for (int index = 0; index < length; ++index)
    {
      tmpsrc[num20 + index] = (uint) this.fpre.fpr_rint(falconFprArray1[index]);
      tmpsrc[num21 + index] = (uint) this.fpre.fpr_rint(falconFprArray2[index]);
    }
    return 1;
  }

  internal int solve_NTRU_binary_depth0(
    uint logn,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    uint[] tmpsrc,
    int tmp)
  {
    int num1 = 1 << (int) logn;
    int length = num1 >> 1;
    uint p = this.PRIMES[0].p;
    uint p0i = this.modp_ninv31(p);
    uint b1 = this.modp_R2(p, p0i);
    int num2 = tmp;
    int a1 = num2 + length;
    int num3 = a1 + length;
    int a2 = num3 + num1;
    int gm1 = a2 + num1;
    int igm1 = gm1 + num1;
    this.modp_mkgm2(tmpsrc, gm1, tmpsrc, igm1, logn, this.PRIMES[0].g, p, p0i);
    for (int index = 0; index < length; ++index)
    {
      tmpsrc[num2 + index] = this.modp_set(this.zint_one_to_plain(tmpsrc, num2 + index), p);
      tmpsrc[a1 + index] = this.modp_set(this.zint_one_to_plain(tmpsrc, a1 + index), p);
    }
    this.modp_NTT2(tmpsrc, num2, tmpsrc, gm1, logn - 1U, p, p0i);
    this.modp_NTT2(tmpsrc, a1, tmpsrc, gm1, logn - 1U, p, p0i);
    for (int index = 0; index < num1; ++index)
    {
      tmpsrc[num3 + index] = this.modp_set((int) fsrc[f + index], p);
      tmpsrc[a2 + index] = this.modp_set((int) gsrc[g + index], p);
    }
    this.modp_NTT2(tmpsrc, num3, tmpsrc, gm1, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a2, tmpsrc, gm1, logn, p, p0i);
    for (int index = 0; index < num1; index += 2)
    {
      uint a3 = tmpsrc[num3 + index];
      uint a4 = tmpsrc[num3 + index + 1];
      uint a5 = tmpsrc[a2 + index];
      uint a6 = tmpsrc[a2 + index + 1];
      uint b2 = this.modp_montymul(tmpsrc[num2 + (index >> 1)], b1, p, p0i);
      uint b3 = this.modp_montymul(tmpsrc[a1 + (index >> 1)], b1, p, p0i);
      tmpsrc[num3 + index] = this.modp_montymul(a6, b2, p, p0i);
      tmpsrc[num3 + index + 1] = this.modp_montymul(a5, b2, p, p0i);
      tmpsrc[a2 + index] = this.modp_montymul(a4, b3, p, p0i);
      tmpsrc[a2 + index + 1] = this.modp_montymul(a3, b3, p, p0i);
    }
    this.modp_iNTT2(tmpsrc, num3, tmpsrc, igm1, logn, p, p0i);
    this.modp_iNTT2(tmpsrc, a2, tmpsrc, igm1, logn, p, p0i);
    int a7 = num2 + num1;
    int num4 = a7 + num1;
    Array.Copy((Array) tmpsrc, num3, (Array) tmpsrc, num2, 2 * num1);
    int num5 = num4 + num1;
    int a8 = num5 + num1;
    int index1 = a8 + num1;
    int a9 = index1 + num1;
    this.modp_mkgm2(tmpsrc, num4, tmpsrc, num5, logn, this.PRIMES[0].g, p, p0i);
    this.modp_NTT2(tmpsrc, num2, tmpsrc, num4, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a7, tmpsrc, num4, logn, p, p0i);
    tmpsrc[index1] = tmpsrc[a9] = this.modp_set((int) fsrc[f], p);
    for (int index2 = 1; index2 < num1; ++index2)
    {
      tmpsrc[index1 + index2] = this.modp_set((int) fsrc[f + index2], p);
      tmpsrc[a9 + num1 - index2] = this.modp_set((int) -fsrc[f + index2], p);
    }
    this.modp_NTT2(tmpsrc, index1, tmpsrc, num4, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a9, tmpsrc, num4, logn, p, p0i);
    for (int index3 = 0; index3 < num1; ++index3)
    {
      uint a10 = this.modp_montymul(tmpsrc[a9 + index3], b1, p, p0i);
      tmpsrc[num5 + index3] = this.modp_montymul(a10, tmpsrc[num2 + index3], p, p0i);
      tmpsrc[a8 + index3] = this.modp_montymul(a10, tmpsrc[index1 + index3], p, p0i);
    }
    tmpsrc[index1] = tmpsrc[a9] = this.modp_set((int) gsrc[g], p);
    for (int index4 = 1; index4 < num1; ++index4)
    {
      tmpsrc[index1 + index4] = this.modp_set((int) gsrc[g + index4], p);
      tmpsrc[a9 + num1 - index4] = this.modp_set((int) -gsrc[g + index4], p);
    }
    this.modp_NTT2(tmpsrc, index1, tmpsrc, num4, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a9, tmpsrc, num4, logn, p, p0i);
    for (int index5 = 0; index5 < num1; ++index5)
    {
      uint a11 = this.modp_montymul(tmpsrc[a9 + index5], b1, p, p0i);
      tmpsrc[num5 + index5] = this.modp_add(tmpsrc[num5 + index5], this.modp_montymul(a11, tmpsrc[a7 + index5], p, p0i), p);
      tmpsrc[a8 + index5] = this.modp_add(tmpsrc[a8 + index5], this.modp_montymul(a11, tmpsrc[index1 + index5], p, p0i), p);
    }
    this.modp_mkgm2(tmpsrc, num4, tmpsrc, index1, logn, this.PRIMES[0].g, p, p0i);
    this.modp_iNTT2(tmpsrc, num5, tmpsrc, index1, logn, p, p0i);
    this.modp_iNTT2(tmpsrc, a8, tmpsrc, index1, logn, p, p0i);
    for (int index6 = 0; index6 < num1; ++index6)
    {
      tmpsrc[num4 + index6] = (uint) this.modp_norm(tmpsrc[num5 + index6], p);
      tmpsrc[num5 + index6] = (uint) this.modp_norm(tmpsrc[a8 + index6], p);
    }
    FalconFPR[] falconFprArray = new FalconFPR[2 * num1];
    int num6 = num1;
    for (int index7 = 0; index7 < num1; ++index7)
      falconFprArray[num6 + index7] = this.fpre.fpr_of((long) (int) tmpsrc[num5 + index7]);
    this.ffte.FFT(falconFprArray, num6, logn);
    int b4 = 0;
    Array.Copy((Array) falconFprArray, num6, (Array) falconFprArray, 0, length);
    int num7 = 0 + length;
    for (int index8 = 0; index8 < num1; ++index8)
      falconFprArray[num7 + index8] = this.fpre.fpr_of((long) (int) tmpsrc[num4 + index8]);
    this.ffte.FFT(falconFprArray, num7, logn);
    this.ffte.poly_div_autoadj_fft(falconFprArray, num7, falconFprArray, b4, logn);
    this.ffte.iFFT(falconFprArray, num7, logn);
    for (int index9 = 0; index9 < num1; ++index9)
      tmpsrc[num4 + index9] = this.modp_set((int) this.fpre.fpr_rint(falconFprArray[num7 + index9]), p);
    int gm2 = num4 + num1;
    int igm2 = gm2 + num1;
    int a12 = igm2 + num1;
    int a13 = a12 + num1;
    this.modp_mkgm2(tmpsrc, gm2, tmpsrc, igm2, logn, this.PRIMES[0].g, p, p0i);
    for (int index10 = 0; index10 < num1; ++index10)
    {
      tmpsrc[a12 + index10] = this.modp_set((int) fsrc[f + index10], p);
      tmpsrc[a13 + index10] = this.modp_set((int) gsrc[g + index10], p);
    }
    this.modp_NTT2(tmpsrc, num4, tmpsrc, gm2, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a12, tmpsrc, gm2, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a13, tmpsrc, gm2, logn, p, p0i);
    for (int index11 = 0; index11 < num1; ++index11)
    {
      uint a14 = this.modp_montymul(tmpsrc[num4 + index11], b1, p, p0i);
      tmpsrc[num2 + index11] = this.modp_sub(tmpsrc[num2 + index11], this.modp_montymul(a14, tmpsrc[a12 + index11], p, p0i), p);
      tmpsrc[a7 + index11] = this.modp_sub(tmpsrc[a7 + index11], this.modp_montymul(a14, tmpsrc[a13 + index11], p, p0i), p);
    }
    this.modp_iNTT2(tmpsrc, num2, tmpsrc, igm2, logn, p, p0i);
    this.modp_iNTT2(tmpsrc, a7, tmpsrc, igm2, logn, p, p0i);
    for (int index12 = 0; index12 < num1; ++index12)
    {
      tmpsrc[num2 + index12] = (uint) this.modp_norm(tmpsrc[num2 + index12], p);
      tmpsrc[a7 + index12] = (uint) this.modp_norm(tmpsrc[a7 + index12], p);
    }
    return 1;
  }

  internal int solve_NTRU(
    uint logn,
    sbyte[] Fsrc,
    int F,
    sbyte[] Gsrc,
    int G,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    int lim,
    uint[] tmpsrc,
    int tmp)
  {
    int length = 1 << (int) logn;
    if (this.solve_NTRU_deepest(logn, fsrc, f, gsrc, g, tmpsrc, tmp) == 0)
      return 0;
    if (logn <= 2U)
    {
      uint depth = logn;
      while (depth-- > 0U)
      {
        if (this.solve_NTRU_intermediate(logn, fsrc, f, gsrc, g, depth, tmpsrc, tmp) == 0)
          return 0;
      }
    }
    else
    {
      uint depth = logn;
      do
      {
        switch (depth--)
        {
          case 0:
          case 1:
          case 2:
            goto label_10;
          default:
            continue;
        }
      }
      while (this.solve_NTRU_intermediate(logn, fsrc, f, gsrc, g, depth, tmpsrc, tmp) != 0);
      goto label_28;
label_10:
      if (this.solve_NTRU_binary_depth1(logn, fsrc, f, gsrc, g, tmpsrc, tmp) == 0 || this.solve_NTRU_binary_depth0(logn, fsrc, f, gsrc, g, tmpsrc, tmp) == 0)
        return 0;
      goto label_12;
label_28:
      return 0;
    }
label_12:
    if (Gsrc == null)
    {
      G = 0;
      Gsrc = new sbyte[length];
    }
    if (this.poly_big_to_small(Fsrc, F, tmpsrc, tmp, lim, logn) == 0 || this.poly_big_to_small(Gsrc, G, tmpsrc, tmp + length, lim, logn) == 0)
      return 0;
    int a1 = tmp;
    int a2 = a1 + length;
    int a3 = a2 + length;
    int a4 = a3 + length;
    int gm = a4 + length;
    FalconSmallPrime[] primes = this.PRIMES;
    uint p = primes[0].p;
    uint p0i = this.modp_ninv31(p);
    this.modp_mkgm2(tmpsrc, gm, tmpsrc, tmp, logn, primes[0].g, p, p0i);
    for (int index = 0; index < length; ++index)
      tmpsrc[a1 + index] = this.modp_set((int) Gsrc[G + index], p);
    for (int index = 0; index < length; ++index)
    {
      tmpsrc[a2 + index] = this.modp_set((int) fsrc[f + index], p);
      tmpsrc[a3 + index] = this.modp_set((int) gsrc[g + index], p);
      tmpsrc[a4 + index] = this.modp_set((int) Fsrc[F + index], p);
    }
    this.modp_NTT2(tmpsrc, a2, tmpsrc, gm, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a3, tmpsrc, gm, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a4, tmpsrc, gm, logn, p, p0i);
    this.modp_NTT2(tmpsrc, a1, tmpsrc, gm, logn, p, p0i);
    uint num = this.modp_montymul(12289U, 1U, p, p0i);
    for (int index = 0; index < length; ++index)
    {
      if ((int) this.modp_sub(this.modp_montymul(tmpsrc[a2 + index], tmpsrc[a1 + index], p, p0i), this.modp_montymul(tmpsrc[a3 + index], tmpsrc[a4 + index], p, p0i), p) != (int) num)
        return 0;
    }
    return 1;
  }

  internal void poly_small_mkgauss(SHAKE256 rng, sbyte[] fsrc, int f, uint logn)
  {
    int num1 = 1 << (int) logn;
    uint num2 = 0;
    for (int index = 0; index < num1; ++index)
    {
      int num3;
      do
      {
        do
        {
          num3 = this.mkgauss(rng, logn);
        }
        while (num3 < -127 || num3 > (int) sbyte.MaxValue);
        if (index != num1 - 1)
          goto label_5;
      }
      while (((int) num2 ^ num3 & 1) == 0);
      goto label_6;
label_5:
      num2 ^= (uint) (num3 & 1);
label_6:
      fsrc[f + index] = (sbyte) num3;
    }
  }

  internal void keygen(
    SHAKE256 rng,
    sbyte[] fsrc,
    int f,
    sbyte[] gsrc,
    int g,
    sbyte[] Fsrc,
    int F,
    sbyte[] Gsrc,
    int G,
    ushort[] hsrc,
    int h,
    uint logn)
  {
    int length = 1 << (int) logn;
    SHAKE256 rng1 = rng;
    uint[] tmpsrc1;
    int lim;
    do
    {
      ushort[] tmpsrc2;
      int h1;
      ushort[] hsrc1;
      int tmp;
      do
      {
        FalconFPR x;
        do
        {
          uint num1;
          uint num2;
          do
          {
            int num3;
            do
            {
              this.poly_small_mkgauss(rng1, fsrc, f, logn);
              this.poly_small_mkgauss(rng1, gsrc, g, logn);
              num3 = 1 << (int) this.codec.max_fg_bits[(int) logn] - 1;
              for (int index = 0; index < length; ++index)
              {
                if ((int) fsrc[f + index] >= num3 || (int) fsrc[f + index] <= -num3 || (int) gsrc[g + index] >= num3 || (int) gsrc[g + index] <= -num3)
                {
                  num3 = -1;
                  break;
                }
              }
            }
            while (num3 < 0);
            num1 = this.poly_small_sqnorm(fsrc, f, logn);
            num2 = this.poly_small_sqnorm(gsrc, g, logn);
          }
          while ((uint) ((ulong) (num1 + num2) | (ulong) -((num1 | num2) >> 31 /*0x1F*/)) >= 16823U);
          FalconFPR[] falconFprArray = new FalconFPR[3 * length];
          int num4 = 0;
          int num5 = 0 + length;
          int num6 = num5 + length;
          this.poly_small_to_fp(falconFprArray, 0, fsrc, f, logn);
          this.poly_small_to_fp(falconFprArray, num5, gsrc, g, logn);
          this.ffte.FFT(falconFprArray, 0, logn);
          this.ffte.FFT(falconFprArray, num5, logn);
          this.ffte.poly_invnorm2_fft(falconFprArray, num6, falconFprArray, 0, falconFprArray, num5, logn);
          this.ffte.poly_adj_fft(falconFprArray, 0, logn);
          this.ffte.poly_adj_fft(falconFprArray, num5, logn);
          this.ffte.poly_mulconst(falconFprArray, 0, this.fpre.fpr_q, logn);
          this.ffte.poly_mulconst(falconFprArray, num5, this.fpre.fpr_q, logn);
          this.ffte.poly_mul_autoadj_fft(falconFprArray, 0, falconFprArray, num6, logn);
          this.ffte.poly_mul_autoadj_fft(falconFprArray, num5, falconFprArray, num6, logn);
          this.ffte.iFFT(falconFprArray, 0, logn);
          this.ffte.iFFT(falconFprArray, num5, logn);
          x = this.fpre.fpr_zero;
          for (int index = 0; index < length; ++index)
            x = this.fpre.fpr_add(this.fpre.fpr_add(x, this.fpre.fpr_sqr(falconFprArray[num4 + index])), this.fpre.fpr_sqr(falconFprArray[num5 + index]));
        }
        while (!this.fpre.fpr_lt(x, this.fpre.fpr_bnorm_max));
        if (hsrc == null)
        {
          tmpsrc2 = new ushort[2 * length];
          h1 = 0;
          hsrc1 = tmpsrc2;
          tmp = 0 + length;
        }
        else
        {
          tmpsrc2 = new ushort[length];
          h1 = h;
          hsrc1 = hsrc;
          tmp = 0;
        }
      }
      while (this.vrfy.compute_public(hsrc1, h1, fsrc, f, gsrc, g, logn, tmpsrc2, tmp) == 0);
      tmpsrc1 = logn > 2U ? new uint[28 * length] : new uint[28 * length * 3];
      lim = (1 << (int) this.codec.max_FG_bits[(int) logn] - 1) - 1;
    }
    while (this.solve_NTRU(logn, Fsrc, F, Gsrc, G, fsrc, f, gsrc, g, lim, tmpsrc1, 0) == 0);
  }
}
