export function newPointerBuffer() {
    return {
        X: [],
        Y: [],
        T: [],
    }
}

export function clearPointerBuffer(data) {
    data.X = []
    data.Y = []
    data.T = []
}
