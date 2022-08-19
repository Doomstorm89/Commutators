using System.Net;

namespace Commutators.Models.Entities
{
    /// <summary>
    /// Управляющий VLAN
    /// </summary>
    public class VLANController
    {
        #region Enum

        /// <summary>
        /// Типы подключений
        /// </summary>
        public enum InterfaceType
        {
            Static,
            Dynamic,
            DHCP
        };

        #endregion

        #region Properties

        private Guid id;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id 
        { 
            get => id;
            private set
            {
                id = Guid.NewGuid();
            }
        }

        private string? ip;
        /// <summary>
        /// IP-адрес
        /// </summary>
        public string? IP
        {
            get => ip;
            set
            {
                if (IPAddress.TryParse(value, out IPAddress ip))
                {
                    this.ip = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Тип подключения
        /// </summary>
        public InterfaceType Type { get; set; } = InterfaceType.Static;

        /// <summary>
        /// Название 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        #endregion
    }
}
