using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam1920.Assets.Scripts.Messages
{
    public class Message : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshPro _dateText;
        [SerializeField] private TMPro.TextMeshPro _coText;
        [SerializeField] private TMPro.TextMeshPro _codewordText;
        [SerializeField] private TMPro.TextMeshPro _orderText;

        private MessageContent _content;

        public void SetContent(MessageContent content)
        {
            _content = content;

            _dateText.text = content.Date;
            _coText.text = content.CommandingOfficer;
            _codewordText.text = content.Codeword;
            _orderText.text = content.Order;
        }

        public bool GetIsCorrect()
        {
            return _content.IsCorrect;
        }

        public ErrorCategory GetErrorCategory()
        {
            return _content.ErrorCategory;
        }
    }
}
