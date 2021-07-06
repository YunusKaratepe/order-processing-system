
class Order {
    constructor(order) {
        this.orderId = order.orderId;
        this.orderNum = order.orderNum;
        this.orderDate = order.orderDate;
        this.orderStatus = order.orderStatus;
        this.orderArrivalDate = order.orderArrivalDate;
        this.orderPaymentType = order.orderPaymentType;
        this.productId = order.productId;
        this.product = order.product;
        this.productQuantity = order.productQuantity;
        this.buyerId = order.buyerId;
        this.buyer = order.buyer;
        this.buyerAddress = order.buyerAddress;
        this.buyerPhoneNum = order.buyerPhoneNum;
        this.sellerId = order.sellerId;
        this.seller = order.seller;
        this.shippingPrice = order.shippingPrice;
        this.billedPrice = order.billedPrice;
        this.toHTML();
    }


    toHTML() {
        this.main = document.createElement("tr");
        let order_num = document.createElement("th");
        let order_date = document.createElement("td");
        let order_status = document.createElement("td");
        let product = document.createElement("td");
        let product_quantity = document.createElement("td");
        let billed_price = document.createElement("td");
        let actions = document.createElement("td");

        order_num.scope = "row";
        this.main.id = "order_" + this.orderNum;
        this.main.setAttribute('data-toggle', "modal");
        this.main.setAttribute('data-target', "#infoModal");

        this.main.onmouseover = () => {
            this.main.style = "background-color: lightgray; cursor: pointer;";
        };

        this.main.onmouseleave = () => {
            this.main.style.backgroundColor = "";
        };

        this.main.onclick = (event) => {
            if (event.srcElement.innerHTML === "Reject") {
                $.ajax({
                    cache: false,
                    type: 'GET',
                    url: '/Home/RejectMe?orderId=' + this.orderId,
                    success: function (response) {
                        location.reload();
                    }
                })
                return;
            }
            
            if (details.getAttribute("hidden")) {
                details.removeAttribute("hidden");
            }
            modal.appendChild(details);
        }

        let details = document.createElement("tr");

        let order_payment_type = document.createElement("p");
        let product_id = document.createElement("p");
        let buyer_id = document.createElement("p");
        let buyer = document.createElement("p");
        let buyer_address = document.createElement("p");
        let buyer_phone_num = document.createElement("p");
        let seller_id = document.createElement("p");
        let seller = document.createElement("p");
        let shipping_price = document.createElement("p");
        let order_arrival_date = document.createElement("p");
        let rejectBtn = document.createElement("button");
        rejectBtn.className = "btn btn-sm btn-danger";

        let modal = document.getElementById('modalBody');
        let closeModalBtn = document.getElementById("closeModalBtn");
        
        closeModalBtn.onclick = () => {
            while (modal.lastElementChild) {
                modal.removeChild(modal.lastElementChild);
            }
        }

        order_num.textContent = this.orderNum;
        order_date.textContent = this.orderArrivalDate;
        order_status.textContent = this.orderStatus;
        product.textContent = this.product;
        billed_price.textContent = this.billedPrice + ' ' + this.orderPaymentType;
        product_quantity.textContent = this.productQuantity;
        
        if (this.orderStatus === 'Rejected') {
            rejectBtn.disabled = true;
        }

        let userRole = document.getElementById('userRole').value;
        if (userRole === 'User') {
            rejectBtn.disabled = true;
        }
        
        rejectBtn.textContent = 'Reject';

        order_arrival_date.textContent = "Arrival Date: " + this.orderArrivalDate;
        order_payment_type.textContent = "Payment Type: " + this.orderPaymentType;
        product.textContent = this.product;
        buyer.textContent = "Buyer: " + this.buyer;
        buyer_address.textContent = "Buyer Address: " + this.buyerAddress;
        buyer_phone_num.textContent = "Buyer Phone Number: " + this.buyerPhoneNum;
        seller.textContent = "Seller: " + this.seller;
        shipping_price.textContent = "Shipping Price: " + this.shippingPrice + " " + this.orderPaymentType;

        order_arrival_date.style = "margin: 1px";
        order_payment_type.style = "margin: 1px";
        product_id.style = "margin: 1px";
        product.style = "margin: 1px";
        buyer_id.style = "margin: 1px";
        buyer.style = "margin: 1px";
        buyer_address.style = "margin: 1px";
        buyer_phone_num.style = "margin: 1px";
        seller_id.style = "margin: 1px";
        seller.style = "margin: 1px";
        shipping_price.style = "margin: 1px";


        details.style.fontSize = "14px";
        details.style.lineHeight = "16px";
        details.appendChild(order_arrival_date);
        details.appendChild(order_payment_type);
        details.appendChild(product);
        details.appendChild(buyer);
        details.appendChild(buyer_address);
        details.appendChild(buyer_phone_num);
        details.appendChild(seller);
        details.appendChild(shipping_price);
        details.setAttribute("hidden", "hidden");
        actions.appendChild(rejectBtn);

        this.main.appendChild(order_num);
        this.main.appendChild(order_date);
        this.main.appendChild(order_status);
        this.main.appendChild(product);
        this.main.appendChild(product_quantity);
        this.main.appendChild(billed_price);
        //this.main.appendChild(details);
        this.main.appendChild(actions);
        modal.appendChild(details); 
    }
    getHTML() {
        console.log(this.main);
        return this.main;
    }
}

// test amaçlı
let order1 = {
    order_num: 001,
    order_date: new Date(Date.now()),
    order_status: 'OnShipment',
    order_arrival_date: new Date(2020, 0, 1, 14, 0), // yıl ay gün saat dakika ...
    order_payment_type: 'Turkish Lira',
    product_id: 098,
    product_name: 'Logitech Klavye',
    product_quantity: 3,
    buyer_id: 00234,
    buyer_address: 'Bursa',
    buyer_phone_num: '+90 242 81 20',
    seller_id: 0023,
    shipping_price: 30.0,
    billed_price: 220.0
}

let order2 = {
    order_num: 002,
    order_date: new Date(Date.now()),
    order_status: 'OnShipment',
    order_arrival_date: new Date(2020, 11, 28, 14, 0), // yıl ay gün saat dakika ...
    order_payment_type: 'Euro',
    product_id: 0235,
    product_name: 'Oyuncu Terliği',
    product_quantity: 20,
    buyer_id: 00234,
    buyer_address: 'İstanbul',
    buyer_phone_num: '+90 224 23 20',
    seller_id: 0023,
    shipping_price: 20.0,
    billed_price: 12.0
}

let order3 = {
    order_num: 023,
    order_date: new Date(Date.now()),
    order_status: 'OnShipment',
    order_arrival_date: new Date(2020, 11, 30, 14, 0), // yıl ay gün saat dakika ...
    order_payment_type: 'Turkish Lira',
    product_id: 0235,
    product_name: 'Oyuncu Koltuğu',
    product_quantity: 1,
    buyer_id: 00234,
    buyer_address: 'İstanbul',
    buyer_phone_num: '+90 224 80 60',
    seller_id: 0023,
    shipping_price: 20.0,
    billed_price: 650.0
}


