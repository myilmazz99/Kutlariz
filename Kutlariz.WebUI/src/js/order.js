let priceInput = document.getElementById("Order_Price");
let price = document.getElementById("price");
let size = document.getElementById("Order_CakeSize");
let typeBoutique = document.getElementById("boutique-cake");
let typeCream = document.getElementById("cream-cake");
let cakeTypes = document.querySelectorAll('input[name="Order.CakeType"]');
let paymentTypes = document.querySelectorAll('input[name="Order.PaymentType"]');

cakeTypes.forEach(input => input.addEventListener('change', e => { alterCakeType(input.value); changePrice() }));
paymentTypes.forEach((input) => input.addEventListener('change', e => changePaymentType(input.value)));
size.addEventListener("change", changePrice);

function alterCakeType(type) {
    if (type === "Boutique" || !type) {
        document.getElementsByClassName("cake-type-description")[0]
            .innerHTML = `Butik pastalarımız geleneksel pastalardan farklı olarak,
                              sizlerin gönderdiği resimlere göre hazırlanmaktadır.
                              Dilediğiniz şekil, logo, resim şeker hamuru kullanılarak pastanıza görüntü kazandırmaktayız.
                              Ödemeye geçmeden önce fotoğraf yüklediğinizden emin olunuz.`;
        document.getElementsByClassName("boutique-cake-picture")[0]
            .classList.remove("hide");
    } else {
        document.getElementsByClassName("cake-type-description")[0]
            .innerHTML = `Kremalı pastalarımız sağlıklı ve taze malzemelerle, seçtiğiniz seçeneklere göre gününde hazırlanmaktadır.`
        document.getElementsByClassName("boutique-cake-picture")[0]
            .classList.add("hide");
    }
}

function changePrice() {
    priceInput.value = 0;
    price.innerHTML = 0;

    if (typeCream.checked) {
        priceInput.value = 100;
        price.innerHTML = 100;
    } else if (typeBoutique.checked) {
        priceInput.value = 150;
        price.innerHTML = 150;
    }

    if (!isNaN(Number(size.value)) && Number(size.value) > 3) {
        priceInput.value = Number(priceInput.value) + (Number(size.value) * 10);
        price.innerHTML = Number(price.innerHTML) + (Number(size.value) * 10);
    }
}

function changePaymentType(type) {
    if (type === "credit" || !type) {
        document.querySelector(".credit-card-form").style.display = "block";
    } else {
        document.querySelector(".credit-card-form").style.display = "none";
    }
}

alterCakeType();
changePaymentType();
