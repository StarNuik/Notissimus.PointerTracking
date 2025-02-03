import {clearPointerBuffer} from "./pointerBuffer.module.js";

export async function sendBuffer(buffer) {
    const postBody = JSON.stringify(buffer)
    clearPointerBuffer(buffer)

    const apiUri = await getApiUri()
    await fetch(apiUri, {
        method: 'POST',
        body: postBody
    })
}

async function getApiUri() {
    const requestUri = window.location.origin + "/api/api-uri"
    const response = await fetch(requestUri)
    const json = await response.json()
    return json.uri
}
