using System.Runtime.Serialization;

namespace Province_API.Core.Domain
{
    public class Enums
    {
        public enum AdministrativeUnitType
        {
            [EnumMember(Value = "Thành phố Trung ương")]
            ThanhPhoTrungUong,

            [EnumMember(Value = "Tỉnh")]
            Tinh,

            [EnumMember(Value = "Quận")]
            Quan,

            [EnumMember(Value = "Huyện")]
            Huyen,

            [EnumMember(Value = "Thành phố")]
            ThanhPho,

            [EnumMember(Value = "Phường")]
            Phuong,

            [EnumMember(Value = "Xã")]
            Xa,

            [EnumMember(Value = "Thị trấn")]
            ThiTran,

            [EnumMember(Value = "Thị xã")]
            ThiXa
        }

    }
}
