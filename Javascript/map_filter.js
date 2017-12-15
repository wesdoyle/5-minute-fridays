// map() filter()
// hardware store example

const products = [
  {'name': 'hammer', 'price': 12.30, 'rating': 4.3},
  {'name': 'chisel', 'price': 4.99, 'rating': 3.5},
  {'name': 'level', 'price': 3.45, 'rating': 2.7},
];

var names = products.map(p => p.name);
console.log(names);

// get an array of boolean values depending on some
// condition of a product's rating:

var result = products.map(p => (p.rating > 4));
console.log(result);

// {'name': 'product_name', 'on_sale': true}

var sale_products = products.map(p => {
    y = {},
    y.name = p.name,
    y.on_sale = (p.rating > 4);
    return y;
});
console.log('sale products:', sale_products);

var expensive = x => x['price'] > 5;
var expensive_products = products.filter(expensive);
console.log('expensive items:', expensive_products);

var query = products.filter(expensive).map(x => x.rating);
console.log(query);
