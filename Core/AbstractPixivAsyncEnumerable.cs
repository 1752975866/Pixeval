﻿// Pixeval - A Strong, Fast and Flexible Pixiv Client
// Copyright (C) 2019 Dylech30th
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Threading;

namespace Pixeval.Core
{
    public abstract class AbstractPixivAsyncEnumerable<T> : IPixivAsyncEnumerable<T>
    {
        protected bool IsCancelled { get; private set; }

        public abstract SortOption SortOption { get; }

        public abstract int RequestedPages { get; protected set; }

        public abstract IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);

        public void Cancel()
        {
            IsCancelled = true;
        }

        public bool IsCancellationRequested()
        {
            return IsCancelled;
        }

        public void ReportRequestedPages()
        {
            RequestedPages++;
        }
    }
}