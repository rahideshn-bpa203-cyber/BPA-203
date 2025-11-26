let card = document.createElement("div");
card.style.width = "350px";
card.style.borderRadius = "12px";
card.style.border="1px solid black"
card.style.overflow = "hidden";
card.style.background = "white";
card.style.margin = "40px auto";
card.style.boxShadow="0 4 px 20 px rgba(0,0,0,0.1)"
card.style.fontFamily = "Arial, sans-serif";


let image = document.createElement("img");
image.src = "https://picsum.photos/200/300";
image.style.width = "100%";
image.style.height = "220px";
image.style.objectFit = "cover";

card.appendChild(image);


let info = document.createElement("div");
info.style.padding = "20px";


let type = document.createElement("p");
type.textContent = "DETACHED HOUSE • 5Y OLD";
type.style.color = "#555";
type.style.fontSize = "14px";
type.style.margin = "0 0 10px 0";

info.appendChild(type);


let price = document.createElement("h2");
price.textContent = "$750,000";
price.style.margin = "0";
price.style.fontSize = "30px";

info.appendChild(price);


let address = document.createElement("p");
address.textContent = "742 Evergreen Terrace";
address.style.margin = "5px 0 15px 0";
address.style.color = "#666";

info.appendChild(address);


let line = document.createElement("hr");
line.style.border = "none";
line.style.height = "2px";
line.style.background = "#eee";

info.appendChild(line);


let specs = document.createElement("div");
specs.style.display = "flex";
specs.style.justifyContent = "space-around";
specs.style.padding = "15px 0";


let bedDiv = document.createElement("div");
bedDiv.innerHTML = "<strong>3</strong> Bedrooms";

specs.appendChild(bedDiv);


let bathDiv = document.createElement("div");
bathDiv.innerHTML = "<strong>2</strong>Bathrooms";

specs.appendChild(bathDiv);

info.appendChild(specs);


let line2 = document.createElement("hr");
line2.style.border = "none";
line2.style.height = "1px";
line2.style.background = "#eee";

info.appendChild(line2);


let realtorBox = document.createElement("div");
realtorBox.style.display = "flex";
realtorBox.style.alignItems = "center";
realtorBox.style.padding = "20px 0";


let realtorTitle = document.createElement("p");
realtorTitle.textContent = "REALTOR";
realtorTitle.style.color = "#666";
realtorTitle.style.fontSize = "12px";
realtorTitle.style.margin = "0 0 10px 0";

info.appendChild(realtorTitle);

let realtor = document.createElement("div");
realtor.style.display = "flex";
realtor.style.alignItems = "center";
realtor.style.gap = "15px";


let realtorImg = document.createElement("img");
realtorImg.src = "https://picsum.photos/id/237/200/300"; 
realtorImg.style.width = "50px";
realtorImg.style.height = "50px";
realtorImg.style.borderRadius = "50%";
realtorImg.style.objectFit = "cover";

realtor.appendChild(realtorImg);


let realtorText = document.createElement("div");
realtorText.innerHTML = `
    <strong>Realtor Name</strong><br>
    (555) 555-4321
`;

realtor.appendChild(realtorText);

info.appendChild(realtor);

card.appendChild(info);

document.body.appendChild(card)