using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Model
{
    public class MaterialModelPaging
    {
        private uint _CurrentPageIndex;
        private uint _PageSize;
        private uint _PageCount;
        private string _SelectByMpn;
        private MaterialModelAccess _Access;
        public MaterialModelPaging(MaterialModelAccess access, uint pageSize, uint pageCount)
        {
            _Access = access;
            _PageSize = pageSize;
            _PageCount = pageCount;
            _SelectByMpn = string.Empty;
            _CurrentPageIndex = 0;
        }

        public MaterialModelPaging(MaterialModelAccess access, uint pageSize, uint pageCount, string mpn)
            :this(access, pageSize, pageCount)
        {
            _SelectByMpn = mpn;            
        }

        public List<MaterialModel> MoveTo(uint pageIndex)
        {
            if (IsOutOfPage(pageIndex) == false)
            {
                _CurrentPageIndex = pageIndex;
                return _Access.Select(pageIndex, (int)_PageSize);
            }
            else
            {
                return new List<MaterialModel>();
            }
        }

        public List<MaterialModel> FirstPage()
        {
            return _Access.Select(0, (int)_PageSize);
        }

        public List<MaterialModel> LastPage()
        {
            return _Access.Select(_PageCount - 1, (int)_PageSize);
        }

        public List<MaterialModel> NextPage()
        {
            if (IsOutOfPage(_CurrentPageIndex + 1) == false)
            {
                _CurrentPageIndex++;
                return _Access.Select(_CurrentPageIndex, (int)_PageSize);
            }
            else
                return new List<MaterialModel>();
        }

        public List<MaterialModel> PrevPage()
        {
            if (_CurrentPageIndex > 0 && IsOutOfPage(_CurrentPageIndex - 1) == false)
            {
                _CurrentPageIndex--;
                return _Access.Select(_CurrentPageIndex, (int)_PageSize);
            }
            else
                return new List<MaterialModel>();
        }

        private bool IsOutOfPage(uint page)
        {
            return page >= _PageCount;
        }
    }
}
