document.addEventListener("mousemove", mouseMoved)

let button = document.getElementById("button")
button.addEventListener("click", sendData)

let data = newPointerData()

function mouseMoved(e) {
    data.X.push(e.x)
    data.Y.push(e.y)
    data.T.push(Date.now())
}

function sendData() {
    alert(JSON.stringify(data))
    data = newPointerData()
}

function newPointerData() {
    return {
        X: [],
        Y: [],
        T: [],
    }
}

function pushPointerData(data, mouseEvent) {
    data.X.push(mouseEvent.x)
    data.Y.push(mouseEvent.y)
    data.T.push(Date.now())
}