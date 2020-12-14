document.querySelector('#sidebar > div:nth-child(2) > form').addEventListener("submit", submitForm);

function submitForm(e) {
    e.preventDefault();
    let name = document.querySelector('#sidebar > div:nth-child(2) > form > div:nth-child(1) > input[type=text]').value;
    let mail = document.querySelector('#sidebar > div:nth-child(2) > form > div:nth-child(2) > input[type=email]').value;
    let subject = document.querySelector('#sidebar > div:nth-child(2) > form > div:nth-child(3) > input[type=text]').value;
    let message = document.querySelector('#sidebar > div:nth-child(2) > form > div:nth-child(4) > textarea').value;

    /*saveContactInfo(name, mail, subject, message);*/
    
    document.querySelector('#sidebar > div:nth-child(2) > form').reset();

    sendEmail(name, mail, subject, message);
}

function sendEmail(name, mail, subject, message) {
    Email.send({
        SecureToken: "f1075cd9-1051-4179-84c8-61e649cff147",
        To: "morten.ingman@ingmandev.se",
        From: "form@ingmandev.se",
        Subject: `${name} har skickat ett meddelande.`,
        Body: `Name: ${name} <br/> Email: ${mail} <br/> Subject: ${subject} <br/> Message: ${message}`,
    }).then((message) => alert("Meddelandet har skickats!"))
} 



