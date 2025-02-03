import {newPointerBuffer} from "./pointerBuffer.module.js"
import {mouseMoved} from "./mouseMoved.module.js";
import {sendBuffer} from "./sendBuffer.module.js";

let buffer = newPointerBuffer()

document.addEventListener("mousemove",
    (e) => mouseMoved(buffer, e))

document.getElementById("button")
    .addEventListener("click",
        () => sendBuffer(buffer))

