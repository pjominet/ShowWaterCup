(ns app.lib)

(def fst #(first %))
(def snd #(get % 1))

(defn get-canvas
  "input: canvas html id (string)
   returns: canvas DOM element"
  [canvasId]
  (.getElementById js/document canvasId))

(defn get-ctx
  "input: canvas DOM element
   returns: canvas 2D context"
  [canvas]
  (.getContext canvas "2d"))

(defn draw-line
  "input: ctx, start and end point [x y]
   effect: draws the line"
  [c start end]
  (.moveTo c (fst start) (snd start))
  (.lineTo c (fst end) (snd end))
  (.stroke c))

(defn bold-line-width [c] (set! (.-lineWidth c) 10))
(defn medium-line-width [c] (set! (.-lineWidth c) 5))
(defn black [c] (set! (.-fillStyle c) "rgb(255,0,0)"))

(defn generate-columns
  "input: ctx, number of columns and width of a column
   returns: list of columns -> [[pointA pointB] ... ]"
  [c nCols colW]
  (reduce
    (fn [acc i]
      (let [colXPos (* colW i)]
        (conj acc [[colXPos 0] [colXPos (.-h c)]])))
    [] ; empty list of col lines
    (range nCols 0 -1)))

(defn generate-rows
  "input: ctx, number of rows and height of a row
   returns: list of rows -> [[pointA pointB] ... ]"
  [c nRows rowH]
  (reduce
    (fn [acc i]
      (let [rowYPos (* rowH i)]
        (conj acc [[0 rowYPos] [(.-w c) rowYPos]])))
    [] ; empty list of col lines
    (range nRows 0 -1)))

(defn draw-lines
  "input: ctx, start iteration and lines vector
   effect: draws all given lines"
  [c iteration linesToDraw]
  (loop [i iteration
         lines linesToDraw]
    (let [line (peek lines)
          a (fst line)
          b (snd line)]
      (draw-line c a b))
    (if (> (count lines) 0)
      (recur (dec i) (pop lines)))))

(defn draw-grid
  "input: ctx, number of rows & cols for grid
   effect: draws the grid on the context"
  [c nRows nCols]
  (let [colW (/ (.-w c) nCols)
        rowH (/ (.-h c) nRows)
        colLines (generate-columns c nCols colW)
        rowLines (generate-rows c nRows rowH)]

    ; draw axis lines
    (bold-line-width c)
    (black c)
    (draw-line c [0 0] [(.-w c) 0]) ; col
    (draw-line c [0 0] [0 (.-h c)]) ; row

    ; draw cols & rows
    (medium-line-width c)
    (draw-lines c (dec nCols) colLines)
    (draw-lines c (dec nRows) rowLines)))

(defn draw-house
  [c]
  (set! (.-fillStyle c) "rgb(255,0,0)")
  (set! (.-lineWidth c) 10)
  (.strokeRect c 75 140 150 110)
  (.fillRect c 130 190 40 60)
  (.moveTo c 50 140)
  (.lineTo c 150 60)
  (.lineTo c 250 140)
  (.closePath c)
  (.stroke c))

(defn startGame
  [canvasId nCols nRows]
  (let [canvas (get-canvas canvasId)
        ctx (get-ctx canvas)]
    (set! (.-w ctx) (.-width canvas))
    (set! (.-h ctx) (.-height canvas))
    (.clearRect ctx 0 0 (.-w ctx) (.-h ctx))
    (draw-grid ctx nCols nRows)))
