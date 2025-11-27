let inputOne = document.querySelector(".input_one");
let inputTwo = document.querySelector(".input_two");
let result = document.querySelector(".result");


function sum() {
    if (inputOne.value === "" || inputTwo.value === "") {
        alert("Xanalari doldurun!");
        return;
    }

    let cavab = Number(inputOne.value) + Number(inputTwo.value);
    result.textContent = "Nəticə: " + cavab;
}


function minus() {
    if (inputOne.value === "" || inputTwo.value === "") {
        alert("Xanalari doldurun!");
        return;
    }

    let cavab = Number(inputOne.value) - Number(inputTwo.value);
    result.textContent = "Nəticə: " + cavab;
}


function mult() {
    if (inputOne.value === "" || inputTwo.value === "") {
        alert("Xanalari doldurun!");
        return;
    }

    let cavab = Number(inputOne.value) * Number(inputTwo.value);
    result.textContent = "Nəticə: " + cavab;
}


function divide() {
    if (inputOne.value === "" || inputTwo.value === "") {
        alert("Xanalari doldurun!");
        return;
    }

    if (Number(inputTwo.value) === 0) {
        alert("0-a bölmək olmaz!");
        return;
    }

    let cavab = Number(inputOne.value) / Number(inputTwo.value);
    result.textContent = "Nəticə: " + cavab;
}


document.querySelector(".plus").addEventListener("click", sum);
document.querySelector(".minus").addEventListener("click", minus);
document.querySelector(".mult").addEventListener("click", mult);
document.querySelector(".divide").addEventListener("click", divide);