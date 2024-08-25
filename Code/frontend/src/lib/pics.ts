export const pics = [
    "@/assets/burger.png",
    "@/assets/fruchtkorb.png",
    "@/assets/salat.png",
    "@/assets/truthan.png",
]

export function getRandomPic(): string {
    const index = Math.floor(Math.random() * pics.length);
    return pics[index];
}