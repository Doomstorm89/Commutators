using System.Net;
using System.Net.NetworkInformation;

namespace Commutators.Models.Entities
{
    /// <summary>
    /// Коммутатор
    /// </summary>
    public class BaseCommutator
    {
        #region Properties

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        public string? Model { get; set; }

        private string? ip;
        /// <summary>
        /// IP-адрес
        /// </summary>
        public string? IP
        {
            get => ip;
            set
            {
                if (IPAddress.TryParse(value, out IPAddress? ip))
                {
                    this.ip = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private string? mac;

        /// <summary>
        /// MAC-адрес
        /// </summary>
        public string? MAC
        {
            get => mac;
            set
            {
                if (PhysicalAddress.TryParse(value, out PhysicalAddress? mac))
                {
                    this.mac = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Управляющий VLAN
        /// </summary>
        public VLANController VLANController { get; set; } = null!;

        private Guid? serialNumber;

        /// <summary>
        /// Серийный номер
        /// </summary>
        public Guid? SerialNumber
        {
            get => serialNumber;
            set
            {
                if (Guid.TryParse(value.ToString(), out Guid serialNumber) && serialNumber != Guid.Empty)
                {
                    this.serialNumber = serialNumber;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private Guid? inventoryNumber;

        /// <summary>
        /// Инвентарный номер
        /// </summary>
        public Guid? InventoryNumber
        {
            get => inventoryNumber;
            set
            {
                if (Guid.TryParse(value.ToString(), out Guid inventoryNumber) && inventoryNumber != Guid.Empty)
                {
                    this.inventoryNumber = inventoryNumber;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }


        private DateTimeOffset? purchaseDate;

        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTimeOffset? PurchaseDate
        {
            get => purchaseDate; 
            set
            {
                if(DateTimeOffset.TryParse(value.ToString(), out DateTimeOffset purchaseDate))
                {
                    this.purchaseDate = purchaseDate;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private DateTimeOffset? installDate;

        /// <summary>
        /// Дата установки
        /// </summary>
        public DateTimeOffset? InstallDate
        {
            get => installDate;
            set
            {
                if (DateTimeOffset.TryParse(value.ToString(), out DateTimeOffset installDate))
                {
                    this.installDate = installDate;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int? floor;

        /// <summary>
        /// Этаж, на котором стоит оборудование
        /// </summary>
        public int? Floor
        {
            get => floor;
            set
            {
                if (int.TryParse(value.ToString(), out int floor))
                {
                    this.floor = floor;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string? Comment { get; set; }

        #endregion
    }
}
