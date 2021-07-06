let orders = [];
let buyers = [];
let sellers = [];
let products = [];

document.addEventListener("DOMContentLoaded", function () {
    if (document.getElementById("list_orders"))
        listOrders();
    if (document.getElementById("list_buyers"))
        listBuyers();
    if (document.getElementById("list_sellers"))
        listSellers();
    if (document.getElementById("list_products"))
        listProducts();
});




function listOrders() {
    initOrdersFromJSONList();
    makeOrderList("list_orders", orders);
};

function listOrdersWithGivenKey(keyType, key) {
    document.getElementById("list_orders").innerHTML = '';
    let filteredOrders = [];
    switch (keyType) {
        case "order_num":
            orders.forEach(order => {
                if (String(order.orderNum).includes(key))
                    filteredOrders.push(order);
            });
            break;
        case "sellerId":
            orders.forEach(order => {
                if (String(order.sellerId).includes(key))
                    filteredOrders.push(order);
            });
            break;
        case "buyer_id":
            orders.forEach(order => {
                if (String(order.buyerId).includes(key))
                    filteredOrders.push(order);
            });
            break;
        case "product_id":
            orders.forEach(order => {
                if (String(order.productId).includes(key))
                    filteredOrders.push(order);
            });
            break;
        case "product_name":
            orders.forEach(order => {
                if (String(order.product).toLowerCase().includes(key))
                    filteredOrders.push(order);
            });
            break;
    }
    console.log(filteredOrders);
    makeOrderList("list_orders", filteredOrders);
}


function listBuyers() {
    initBuyersFromJSONList();
};

function listSellers() {
    initSellersFromJSONList();
};

function listProducts() {
    initProductsFromJSONList();
};



// veri tabanından json formatındaki orderleri çek ve Order listesine ekle.
function initOrdersFromJSONList() {
    $.ajax({
        cache: false,
        type: 'GET',
        url: '/Home/GetOrders',
        success: function (response) {
            console.log('geldim kardeş');
            response.forEach(orderJSON => {
                orders.push(new Order(orderJSON));
                setOrders(orders);
            });
            makeOrderList("list_orders", orders);
        },
    })
}

// veri tabanından json formatındaki buyerleri çek ve Buyer listesine ekle.
function initBuyersFromJSONList() {
    $.ajax({
        cache: false,
        type: 'GET',
        url: '/Home/GetBuyers',
        success: function (response) {
            response.forEach(buyerJSON => {
                buyers.push(new Buyer(buyerJSON));
                setOrders(orders);
            });
            makeBuyerList("list_buyers");
        }
    })
}

// veri tabanından json formatındaki buyerleri çek ve Seller listesine ekle.
function initSellersFromJSONList() {
    $.ajax({
        cache: false,
        type: 'GET',
        url: '/Home/GetSellers',
        success: function (response) {
            response.forEach(sellersJSON => {
                sellers.push(new Seller(sellersJSON));
                setSellers(sellers);
            });
            makeSellerList("list_sellers");
        }
    })
}

function initProductsFromJSONList() {
    $.ajax({
        cache: false,
        type: 'GET',
        url: '/Home/GetProducts',
        success: function (response) {
            console.log(response);
            response.forEach(productJSON => {
                products.push(new Product(productJSON));
                setProducts(products);
            });
            makeProductList("list_products");
        }
    })
}

function setOrders(list) {
    orders = list;
}

function setBuyers(list) {
    buyers = list;
}

function setSellers(list) {
    sellers = list;
}

function setProducts(list) {
    products = list;
}

// HTML Order Listesi
function makeOrderList(surroundingDivId, orders) {
    let surroundingDiv = document.getElementById(surroundingDivId);
    orders.forEach(order => {
        surroundingDiv.appendChild(order.getHTML());
    });
} 

// HTML Buyer Listesi
function makeBuyerList(surroundingDivId) {
    let surroundingDiv = document.getElementById(surroundingDivId);
    buyers.forEach(buyer => {
        surroundingDiv.appendChild(buyer.getHTML());
    });
}

// HTML Seller Listesi
function makeSellerList(surroundingDivId) {
    let surroundingDiv = document.getElementById(surroundingDivId);
    sellers.forEach(seller => {
        surroundingDiv.appendChild(seller.getHTML());
    });
} 

// HTML Product Listesi
function makeProductList(surroundingDivId) {
    let surroundingDiv = document.getElementById(surroundingDivId);
    products.forEach(product => {
        surroundingDiv.appendChild(product.getHTML());
    });
} 

function deleteSeller() {
    
    let deleteIndex;
    let deleteSellerWithThisId;

    sellers.forEach((seller, index) => {
        if (seller.isSelected == true) {
            // todo sil
            deleteSellerWithThisId = seller.getId();
            deleteIndex = index;
            return;
        }
    });
    
    console.log("Silinen Seller ID: " + deleteSellerWithThisId);
    sellers.splice(deleteIndex, 1);

    //
    // burada seller veritabanından da silinecek (yukarda alınan id ye göre)
    //... 
}

searchOrderIdTextChanged = function () {
    listOrdersWithGivenKey('order_num', document.getElementById("search_by_order_id_text").value);
};
searchSellerIdTextChanged = function () {
    listOrdersWithGivenKey('seller_id', document.getElementById("search_by_seller_id_text").value);
};
searchBuyerIdTextChanged = function () {
    listOrdersWithGivenKey('buyer_id', document.getElementById("search_by_buyer_id_text").value);
};
searchProductIdTextChanged = function () {
    listOrdersWithGivenKey('product_id', document.getElementById("search_by_product_id_text").value);
};
searchProductNameTextChanged = function () {
    listOrdersWithGivenKey('product_name', document.getElementById("search_by_product_name_text").value.toLowerCase());
};