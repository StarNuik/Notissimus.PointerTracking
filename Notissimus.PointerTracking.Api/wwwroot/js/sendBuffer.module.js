import {clearPointerBuffer} from "./pointerBuffer.module.js";

export async function sendBuffer(buffer) {
    const postBody = JSON.stringify(buffer)
    clearPointerBuffer(buffer)

    const requestUri = window.location.origin + "/api/pointer-tracking"
    await fetch(requestUri, {
        method: 'POST',
        body: postBody,
        headers: {
            "Content-Type": "application/json"
        },
    })
}
