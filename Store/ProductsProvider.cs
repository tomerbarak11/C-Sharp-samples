using System;
using System.Collections.Generic;
using System.Text;

namespace AteraAssignment
{
    public interface ProductsProvider
    {
        List<Product> readProducts();
    }
}
