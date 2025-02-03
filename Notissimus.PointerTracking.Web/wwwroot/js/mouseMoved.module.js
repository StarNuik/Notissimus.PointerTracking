export function mouseMoved(buffer, event) {
    buffer.X.push(event.x)
    buffer.Y.push(event.y)
    buffer.T.push(Date.now())
}

