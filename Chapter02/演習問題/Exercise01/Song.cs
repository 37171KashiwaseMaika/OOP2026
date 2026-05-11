using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //クラス2.1.1
    public class Song {
        //タイトル
        public string Title { get; set; } = string.Empty;
        //アーティスト名
        public string ArtistName { get; set; } = string.Empty;
        //時間
        public int Length { get; set; }

        //コンストラクタ2.1.2
        public Song(string title,string artistName,int length) {
            Title = title;
            ArtistName = artistName;
            Length = length;
        }


    }
}
