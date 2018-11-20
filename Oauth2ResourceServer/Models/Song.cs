using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Oauth2ResourceServer.Models
{
    public class Song
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Singer { get; set; }
        public string Author { get; set; }
        public string Thumbnail { get; set; }
        public string Link { get; set; }
        public int CategoryId { get; set; }
        public long AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public SongStatus Status { get; set; }
        public virtual Category Category { get; set; }
        
//        [
//    {
//        "id": 1,
//        "name": "Counting Stars",
//        "description": "Hot Song",
//        "singer": "OneRepublic",
//        "author": "Ryan Tedder",
//        "thumbnail": "https://upload.wikimedia.org/wikipedia/en/thumb/3/37/OneRepublic_Counting_Stars_cover.png/220px-OneRepublic_Counting_Stars_cover.png",
//        "link": "https://od.lk/s/NjFfMjQwMTk3NjRf/CountingStars-OneRepublic-5506215.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T03:28:57.6928403",
//        "updatedAt": "2018-11-16T03:28:57.6928443",
//        "status": 1
//    },
//    {
//        "id": 2,
//        "name": "Không Thể Chạm Được Em",
//        "description": "Hot Song",
//        "singer": " Gin Tuấn Kiệt",
//        "author": " Gin Tuấn Kiệt",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/11/06/1/9/5/0/1541493045342.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui970/KhongTheChamDuocEm-GinTuanKiet-5732705.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T04:16:27.5329868",
//        "updatedAt": "2018-11-16T04:16:27.5329903",
//        "status": 1
//    },
//    {
//        "id": 3,
//        "name": "Giá Như Mình Đã Bao Dung",
//        "description": "Hot Song",
//        "singer": " Hồ Ngọc Hà",
//        "author": " Nguyễn Hồng Thuận",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/10/31/5/5/0/d/1540982554822.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui970/GiaNhuMinhDaBaoDung-HoNgocHa-5726665.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T04:33:06.5603104",
//        "updatedAt": "2018-11-16T04:33:06.5603218",
//        "status": 1
//    },
//    {
//        "id": 4,
//        "name": "Cuộc Sống Mà ",
//        "description": "Hot Song",
//        "singer": " Yong Anhh",
//        "author": "  Yong Anhh",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/11/06/1/9/5/0/1541495996031.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui970/CuocSongMa-YongAnhh-5732726.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T04:37:19.9277007",
//        "updatedAt": "2018-11-16T04:37:19.9277038",
//        "status": 1
//    },
//    {
//        "id": 5,
//        "name": "Em Không Thể",
//        "description": "Hot Song",
//        "singer": "Tiên Tiên, Touliver",
//        "author": "Tiên Tiên",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/10/26/e/f/9/9/1540554616792.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui970/EmKhongThe-TienTienTouliver-5716864.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T04:39:48.9682295",
//        "updatedAt": "2018-11-16T04:39:48.9682329",
//        "status": 1
//    },
//    {
//        "id": 6,
//        "name": "Như Lời Đồn",
//        "description": "Hot Song",
//        "singer": " Bảo Anh",
//        "author": "Khắc Hưng",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/10/11/2/f/4/7/1539252733451.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui969/NhuLoiDon-BaoAnh-5700656.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T04:41:30.1659551",
//        "updatedAt": "2018-11-16T04:41:30.1659581",
//        "status": 1
//    },
//    {
//        "id": 7,
//        "name": "Em Đâu Biết",
//        "description": "Hot Song",
//        "singer": " SunD, BigDaddy, Rhymastic",
//        "author": "Rhymastic",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/10/25/2/c/5/2/1540451445590.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui969/NhuLoiDon-BaoAnh-5700656.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T04:43:02.5111887",
//        "updatedAt": "2018-11-16T04:43:02.5111918",
//        "status": 1
//    },
//    {
//        "id": 8,
//        "name": "Là Cả Bầu Trời",
//        "description": "Hot Song",
//        "singer": " Hari Won",
//        "author": "Nguyễn Hồng Thuận",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/10/17/d/0/b/7/1539746774638.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui970/LaCaBauTroi-HariWon-5708204.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T04:51:51.7203756",
//        "updatedAt": "2018-11-16T04:51:51.7203868",
//        "status": 1
//    },
//    {
//        "id": 10,
//        "name": "Giá Như Mình Đã Bao Dung",
//        "description": "Hot Song",
//        "singer": " Hồ Ngọc Hà",
//        "author": " Nguyễn Hồng Thuận",
//        "thumbnail": "https://avatar-nct.nixcdn.com/song/2018/10/31/5/5/0/d/1540982554822.jpg",
//        "link": "https://c1-ex-swe.nixcdn.com/NhacCuaTui970/GiaNhuMinhDaBaoDung-HoNgocHa-5726665.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-16T05:18:31.7947319",
//        "updatedAt": "2018-11-16T05:18:31.7947348",
//        "status": 1
//    },
//    {
//        "id": 12,
//        "name": "Người Lạ Thoáng Qua",
//        "description": "Người Lạ Thoáng Qua",
//        "singer": "Người Lạ Thoáng Qua",
//        "author": "Người Lạ Thoáng Qua",
//        "thumbnail": "https://photo-resize-zmp3.zadn.vn/w240h240_jpeg/cover/4/1/8/b/418b2a3ada550ed8a42f363194a12f45.jpg",
//        "link": "https://vnso-qt-3-tf-mp3-s1-zmp3.zadn.vn/e3cd26c7eb8302dd5b92/2425880662979204580?authen=exp=1542678742~acl=/e3cd26c7eb8302dd5b92/*~hmac=ed637cba8096daa80baae20a2f531cbd&filename=Nguoi-La-Thoang-Qua-Khoi-My.mp3",
//        "memberId": 0,
//        "createdAt": "2018-11-19T02:48:49.3863692",
//        "updatedAt": "2018-11-19T02:48:49.3863725",
//        "status": 1
//    }
//]


        public Song()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = SongStatus.Available;
        }
    }

    public enum SongStatus
    {
        Available = 1,
        Deleted = 0
    }
}
