http://localhost:5750/Products //All products
http://localhost:5750/Products/GetProductsIsFantastic/false //Products where product.attribute.fantastic.value equals false
http://localhost:5750/Products/GetProductsIsFantastic/true //Products where product.attribute.fantastic.value equals true
http://localhost:5750/Products/GetProductsFilterPriceMinMax/false //All products order by product.price max
http://localhost:5750/Products/GetProductsFilterPriceMinMax/true //All products order by product.price min
http://localhost:5750/Products/GetProductsFilterRatingMinMax/true //All products order by product.attribute.rating.value min
http://localhost:5750/Products/GetProductsFilterRatingMinMax/false //All products order by product.attribute.rating.value max
http://localhost:5750/Products/GetProductsFilterPriceMinMax/false/true //All products order by product.price max and product.attribute.fantastic.value equals true
http://localhost:5750/Products/GetProductsFilterPriceMinMax/false/false //All products order by product.price max and product.attribute.fantastic.value equals false
http://localhost:5750/Products/GetProductsFilterPriceMinMax/true/true //All products order by product.price min and product.attribute.fantastic.value equals true
http://localhost:5750/Products/GetProductsFilterPriceMinMax/true/false //All products order by product.price min and product.attribute.fantastic.value equals false
http://localhost:5750/Products/GetProductsFilterRatingMinMax/true/true //All products order by product.attribute.rating.value min and product.attribute.fantastic.value equals true
http://localhost:5750/Products/GetProductsFilterRatingMinMax/true/false //All products order by product.attribute.rating.value min and product.attribute.fantastic.value equals false
http://localhost:5750/Products/GetProductsFilterRatingMinMax/false/true //All products order by product.attribute.rating.value max and product.attribute.fantastic.value equals true
http://localhost:5750/Products/GetProductsFilterRatingMinMax/false/false //All products order by product.attribute.rating.value max and product.attribute.fantastic.value equals false